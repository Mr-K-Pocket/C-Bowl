using DapperService.DataAccess;
using DapperService.Model;
using DapperService.ServiceHelper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Utilities;

namespace DapperService.Service
{
    public class EnrollmentService
    {
        private EnrollmentDataAccess enrollmentDA = new EnrollmentDataAccess();
        private string rootKey = "EnrollmentWithStudent";
        public async Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            return await enrollmentDA.GetAllEntities();
        }

        public async Task<Enrollment> GetEnrollmentByID(int enrollmentID)
        {
            return await enrollmentDA.GetEntityById(enrollmentID);
        }

        public async Task<IEnumerable<Enrollment>> GetAllStudentsWithEnrollments()
        {
            string cacheKey = CacheKeyHelper.GetAllCacheKey(rootKey);
            List<Enrollment> cachedItem = DataCache.GetCachedItem<List<Enrollment>>(cacheKey);

            if (cachedItem == null)
            {
                var enrollList = await enrollmentDA.GetAllStudentsWithEnrollment();
                
                DataCache.SetCachedItem(enrollList.ToList(),cacheKey);
                cachedItem = DataCache.GetCachedItem<List<Enrollment>>(cacheKey);
            }

            return cachedItem;
        }

        public async Task<Enrollment> CreateEnrollment(Enrollment enrollment)
        {
            DataCache.RemoveCacheByKey(CacheKeyHelper.GetAllCacheKey(rootKey));
            return await enrollmentDA.CreateEntity(enrollment);
        }

        public async Task<int> UpdateEnrollment(Enrollment enrollment)
        {
            DataCache.RemoveCacheByKey(CacheKeyHelper.GetAllCacheKey(rootKey));
            return await enrollmentDA.UpdateEntity(enrollment);
        }

        public async Task<int> DeleteEnrollment(int enrollmentID)
        {
            DataCache.RemoveCacheByKey(CacheKeyHelper.GetAllCacheKey(rootKey));
            return await enrollmentDA.DeleteEntity(enrollmentID);
        }
    }
}
