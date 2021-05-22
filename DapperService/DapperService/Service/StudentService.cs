using DapperService.DataAccess;
using DapperService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperService.Service
{
    public class StudentService
    {
        private StudentDataAccess studentDA = new StudentDataAccess();

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await studentDA.GetAllEntities();
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
