using DapperService.GenericService;
using DapperService.Model;

namespace DapperService.DataAccess
{
    public class CourseDataAccess : GenericService<Course>
    {
        public CourseDataAccess()
        {
            tableName = "Course";
            primaryKey = "CourseID";
            insertColumns = "(@Title, @Credits)";
            updateColumns = "Title = @Title, Credits = @Credits";
        }
    }
}
