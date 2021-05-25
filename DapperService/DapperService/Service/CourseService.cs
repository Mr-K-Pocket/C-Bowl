using DapperService.DataAccess;
using DapperService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utility.Utilities;

namespace DapperService.Service
{
    public class CourseService
    {
        private CourseDataAccess courseDA = new CourseDataAccess();
        private string rootKey = "Course";
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            string cacheKey = rootKey + "|All";
            List<Course> cachedItem = DataCache.GetCachedItem<List<Course>>(cacheKey);

            return (cachedItem == null ? await courseDA.GetAllEntities() : cachedItem);
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
