using DapperService.GenericService;
using DapperService.Model;

namespace DapperService.Service
{
    public class CourseService : GenericService<Course>
    {
        public CourseService()
        {
            tableName = "Course";
            primaryKey = "CourseID";
            insertColumns = "(@Title, @Credits)";
            updateColumns = "Title = @Title, Credits = @Credits";
        }
    }
}
