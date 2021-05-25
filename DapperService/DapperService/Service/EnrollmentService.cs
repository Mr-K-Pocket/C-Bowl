using DapperService.DataAccess;
using DapperService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utility.Utilities;

namespace DapperService.Service
{
    public class EnrollmentService
    {
        private EnrollmentDataAccess enrollmentDA = new EnrollmentDataAccess();
        private string rootKey = "Enrollment";
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
            string cacheKey = rootKey + "WithStudent|All";
            List<Enrollment> cachedItem = DataCache.GetCachedItem<List<Enrollment>>(cacheKey);

            return (cachedItem == null ? await enrollmentDA.GetAllStudentsWithEnrollment() : cachedItem);
        }

        public async Task<Enrollment> CreateEnrollment(Enrollment enrollment)
        {
            return await enrollmentDA.CreateEntity(enrollment);
        }

        public async Task<int> UpdateEnrollment(Enrollment enrollment)
        {
            return await enrollmentDA.UpdateEntity(enrollment);
        }

        public async Task<int> DeleteEnrollment(int enrollmentID)
        {
            return await enrollmentDA.DeleteEntity(enrollmentID);
        }
    }
}
