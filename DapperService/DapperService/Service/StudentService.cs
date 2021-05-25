using DapperService.DataAccess;
using DapperService.Model;
using System.Collections.Generic;
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
            string cacheKey = rootKey + "|All";
            List<Student> cachedItem = DataCache.GetCachedItem<List<Student>>(cacheKey);

            return (cachedItem == null ? await studentDA.GetAllEntities() : cachedItem);
        }

        public async Task<Student> GetStudentByID(int studentID)
        {
            return await studentDA.GetEntityById(studentID);
        }

        public async Task<Student> GetStudentWithEnrollment(int studentID)
        {
            return await studentDA.GetStudentWithEnrollment(studentID);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            return await studentDA.CreateEntity(student);
        }

        public async Task<int> UpdateStudent(Student student)
        {
            return await studentDA.UpdateEntity(student);
        }

        public async Task<int> DeleteStudent(int studentID)
        {
            return await studentDA.DeleteEntity(studentID);
        }
    }
}
