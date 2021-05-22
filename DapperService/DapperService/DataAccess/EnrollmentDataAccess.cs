using DapperService.GenericService;
using DapperService.Model;

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
    }
}
