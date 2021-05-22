using Dapper;
using DapperService.GenericService;
using DapperService.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperService.DataAccess
{
    public class StudentDataAccess : GenericService<Student>
    {
        public StudentDataAccess()
        {
            tableName = "Student";
            primaryKey = "StudentID";
            insertColumns = "(@FirstName, @LastName, @EnrollmentDate)";
            updateColumns = "FirstName = @FirstName, LastName = @LastName, EnrollmentDate = @EnrollmentDate";
        }

        public async Task<Student> GetStudentWithEnrollment(int studentID)
        {
            Student stud = new Student();
            var studentDictionary = new Dictionary<int, Student>();

            try
            {
                using (db = new SqlConnection(connectionString))
                {
                    await db.QueryAsync<Student, Enrollment, Student>(@"
                        SELECT s.StudentID, s.FirstName, s.LastName, e.CourseID, c.Title, e.Grade
                        FROM Student AS s 
                        JOIN Enrollment AS e ON s.StudentID = e.StudentID
                        JOIN Course AS c ON e.CourseID = c.CourseID
                        ",
                            (student, enrollment) =>
                            {
                                Student tempStu;

                                if (!studentDictionary.TryGetValue(student.StudentID, out tempStu))
                                {
                                    tempStu = student;
                                    tempStu.Enrollments = new List<Enrollment>();
                                    studentDictionary.Add(tempStu.StudentID, tempStu);
                                }

                                tempStu.Enrollments.Add(enrollment);
                                return tempStu;
                            },
                            splitOn: "CourseID"
                            );
                }

                studentDictionary.TryGetValue(studentID, out stud);
                return stud;
            }
            catch(Exception ex)
            {
                Logger.Logger.LogError("Error occured when get students with enrollments", ex);
                throw;
            }
        }
    }
}
