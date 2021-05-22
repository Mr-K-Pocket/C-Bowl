using DapperService.GenericService;
using DapperService.Model;

namespace DapperService.Service
{
    public class EnrollmentService : GenericService<Enrollment>
    {
        public EnrollmentService()
        {
            tableName = "Enrollment";
            primaryKey = "EnrollmentID";
            insertColumns = "(@CourseID, @StudentID, @Grade)";
            updateColumns = "Grade = @Grade";
        }
    }
}
