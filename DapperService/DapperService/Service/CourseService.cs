using DapperService.DataAccess;
using DapperService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperService.Service
{
    public class CourseService
    {
        private CourseDataAccess courseDA = new CourseDataAccess();

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await courseDA.GetAllEntities();
        }

        public async Task<Course> GetCourseByID(int courseID)
        {
            return await courseDA.GetEntityById(courseID);
        }

        public async Task<Course> CreateCourse(Course course)
        {
            return await courseDA.CreateEntity(course);
        }

        public async Task<int> UpdateCourse(Course course)
        {
            return await courseDA.UpdateEntity(course);
        }

        public async Task<int> DeleteCourse(int courseID)
        {
            return await courseDA.DeleteEntity(courseID);
        }
    }
}
