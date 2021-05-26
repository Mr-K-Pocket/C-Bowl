using DapperService.DataAccess;
using DapperService.Model;
using DapperService.ServiceHelper;
using System.Collections.Generic;
using System.Linq;
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
            string cacheKey = CacheKeyHelper.GetAllCacheKey(rootKey);
            List<Course> cachedItem = DataCache.GetCachedItem<List<Course>>(cacheKey);

            if (cachedItem == null)
            {
                var courseList = await courseDA.GetAllEntities();

                DataCache.SetCachedItem(courseList.ToList(),cacheKey);
                cachedItem = DataCache.GetCachedItem<List<Course>>(cacheKey);
            }

            return cachedItem;
        }

        public async Task<Course> GetCourseByID(int courseID)
        {
            return await courseDA.GetEntityById(courseID);
        }

        public async Task<Course> CreateCourse(Course course)
        {
            DataCache.RemoveCacheByKey(CacheKeyHelper.GetAllCacheKey(rootKey));
            return await courseDA.CreateEntity(course);
        }

        public async Task<int> UpdateCourse(Course course)
        {
            DataCache.RemoveCacheByKey(CacheKeyHelper.GetAllCacheKey(rootKey));
            return await courseDA.UpdateEntity(course);
        }

        public async Task<int> DeleteCourse(int courseID)
        {
            DataCache.RemoveCacheByKey(CacheKeyHelper.GetAllCacheKey(rootKey));
            return await courseDA.DeleteEntity(courseID);
        }
    }
}
