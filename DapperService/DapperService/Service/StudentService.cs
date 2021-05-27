using DapperService.DataAccess;
using DapperService.Model;
using DapperService.ServiceHelper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Utilities;

namespace DapperService.Service
{
    public class StudentService
    {
        private StudentDataAccess studentDA = new StudentDataAccess();
        private string rootKey = "Student";

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            string cacheKey = CacheKeyHelper.GetAllCacheKey(rootKey);
            List<Student> cachedItem = DataCache.GetCachedItem<List<Student>>(cacheKey);

            if (cachedItem == null)
            {
                var stuList = await studentDA.GetAllEntities();

                DataCache.SetCachedItem<List<Student>>(stuList.ToList(), cacheKey);
                cachedItem = DataCache.GetCachedItem<List<Student>>(cacheKey);
            }

            return cachedItem;
        }

        public async Task<Student> GetStudentByID(int studentID)
        {
            return await studentDA.GetEntityById(studentID);
        }

        public async Task<Student> GetStudentWithEnrollment(int studentID)
        {
            return await studentDA.GetStudentWithEnrollment(studentID);
        }

        public async Task<IEnumerable<Student>> SearchStudentByKeyword(string keyword)
        {
            return await studentDA.GetStudentByKeyword(keyword);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            DataCache.RemoveCacheByKey(CacheKeyHelper.GetAllCacheKey(rootKey));
            return await studentDA.CreateEntity(student);
        }

        public async Task<int> UpdateStudent(Student student)
        {
            DataCache.RemoveCacheByKey(CacheKeyHelper.GetAllCacheKey(rootKey));
            return await studentDA.UpdateEntity(student);
        }

        public async Task<int> DeleteStudent(int studentID)
        {
            DataCache.RemoveCacheByKey(CacheKeyHelper.GetAllCacheKey(rootKey));
            return await studentDA.DeleteEntity(studentID);
        }
    }
}
