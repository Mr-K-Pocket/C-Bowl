using EntityModel.Models;

namespace Service.ViewModel
{
    public class StudentCourseEnrollment
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Title { get; set; }
        public int Credits { get; set; }
        public Grade? Grade { get; set; }
    }
}
