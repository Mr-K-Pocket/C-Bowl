using Dapper;
using DapperService.GenericService;
using DapperService.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperService.DataAccess
{
    public class EnrollmentDataAccess : GenericService<Enrollment>
    {
        public EnrollmentDataAccess()
        {
            tableName = "Enrollment";
            primaryKey = "EnrollmentID";
            insertColumns = "(@CourseID, @StudentID, @Grade)";
            updateColumns = "Grade = @Grade";
        }

        public async Task<IEnumerable<Enrollment>> GetAllStudentsWithEnrollment()
        {
            try
            {
                using (db = new SqlConnection(connectionString))
                {
                    return await db.QueryAsync<Enrollment>(@"
                        SELECT s.StudentID, s.FirstName, s.LastName, c.CourseID, c.Title, e.Grade, e.EnrollmentID
                        FROM Student AS s
                        JOIN Enrollment AS e ON s.StudentID = e.StudentID
                        JOIN Course AS c ON e.CourseID = c.CourseID
                    ");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Error occured when get all students with enrollments", ex);
                throw;
            }
        }
    }
}
