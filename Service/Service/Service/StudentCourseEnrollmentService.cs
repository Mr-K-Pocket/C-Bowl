using Service.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class StudentCourseEnrollmentService
    {
        private StudentService stuSvr;
        private CourseService courseSvr;
        private EnrollmentService enrollmentSvr;

        public StudentCourseEnrollmentService()
        {
            stuSvr = new StudentService();
            courseSvr = new CourseService();
            enrollmentSvr = new EnrollmentService();
        }

        public async Task<List<StudentCourseEnrollment>> GetStudentEnrollments(int studentID)
        {
            var stuList = await stuSvr.GetAllStudents();
            var enrollList = await enrollmentSvr.GetAllEnrollments();
            var courseList = await courseSvr.GetAllCourses();

            var result = (from e in enrollList
                         join s in stuList on e.StudentID equals s.StudentID
                         into es
                         from subSE in es.DefaultIfEmpty()
                         join c in courseList on e.CourseID equals c.CourseID
                         where subSE.StudentID == studentID
                         select new StudentCourseEnrollment()
                         {
                             StudentID = subSE.StudentID,
                             CourseID = c.CourseID,
                             FirstName = subSE.FirstName,
                             LastName = subSE.LastName,
                             Title = c.Title,
                             Credits = c.Credits,
                             Grade = e.Grade
                         }).
                         ToList();

            return result;
        }
    }
}
