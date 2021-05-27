using Dapper;
using DapperService.GenericService;
using DapperService.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
                        LEFT JOIN Enrollment AS e ON s.StudentID = e.StudentID
                        LEFT JOIN Course AS c ON e.CourseID = c.CourseID
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

                                if (enrollment != null)
                                {
                                    tempStu.Enrollments.Add(enrollment);
                                }
                                
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

        public async Task<IEnumerable<Student>> GetStudentByKeyword(string keyword)
        {
            try
            {
                using (db = new SqlConnection(connectionString))
                {
                    return await db.QueryAsync<Student>("dbo.dbo_Student_SearchStudentByKeyword", new { keyword = keyword}, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Error occured when search students by keyword", ex);
                throw;
            }
        }
    }
}
