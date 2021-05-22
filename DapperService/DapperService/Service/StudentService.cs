using DapperService.GenericService;
using DapperService.Model;

namespace DapperService.Service
{
    public class StudentService : GenericService<Student>
    {
        public StudentService()
        {
            tableName = "Student";
            primaryKey = "StudentID";
            insertColumns = "(@FirstName, @LastName, @EnrollmentDate)";
            updateColumns = "FirstName = @FirstName, LastName = @LastName, EnrollmentDate = @EnrollmentDate";
        }
    }
}
