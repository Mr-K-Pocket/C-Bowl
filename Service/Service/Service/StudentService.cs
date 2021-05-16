using EntityModel.Models;
using Service.GenericRepo;
using Service.UnitOfWork;
using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class StudentService
    {
        private GenericRepository<Student> genericRepo;
        private GenericUnitOfWork unitOfWork;

        public StudentService() {
            unitOfWork = new GenericUnitOfWork();
            genericRepo = unitOfWork.GetGenericRepositoryInstance<Student>();
        }

        public async Task<List<StudentViewModel>> GetAllStudents()
        {
            var stuList = await genericRepo.GetAllEntities();
            var result = (from s in stuList
                         select new StudentViewModel()
                         {
                             StudentID = s.StudentID,
                             FirstName = s.FirstName,
                             LastName = s.LastName,
                             EnrollmentDate = s.EnrollmentDate
                         })
                         .ToList();

            return result;
        }

        public async Task<StudentViewModel> GetStudentById(int studentID)
        {
            var student = await genericRepo.GetByEntityID(studentID);
            var result = student != null ?
                         new StudentViewModel()
                         {
                             StudentID = student.StudentID,
                             FirstName = student.FirstName,
                             LastName = student.LastName,
                             EnrollmentDate = student.EnrollmentDate
                         } : null;

            if (result == null)
            {
                throw new NullReferenceException("Can not find the student by id.");
            }

            return result;
        }

        public Student CreateStudent(StudentViewModel stuVM)
        {
            if(stuVM == null)
            {
                throw new ArgumentNullException("Student view model is null.");
            }

            var result = genericRepo.AddEntity(Adapt(stuVM));

            return result;
        }

        public Student UpdateStudent(StudentViewModel stuVM)
        {
            if (stuVM == null)
            {
                throw new ArgumentNullException("Student view model is null.");
            }

            var result = genericRepo.UpdateEntity(Adapt(stuVM));

            return result;
        }

        public Student DeleteStudent(StudentViewModel stuVM)
        {
            if (stuVM == null)
            {
                throw new ArgumentNullException("Student view model is null.");
            }

            var result = genericRepo.DeleteEntity(Adapt(stuVM));

            return result;
        }

        public Student Adapt(StudentViewModel stuVM)
        {
            Student student = new Student()
            {
                FirstName = stuVM.FirstName,
                LastName = stuVM.LastName,
                EnrollmentDate = stuVM.EnrollmentDate
            };

            return student;
        }
    }
}
