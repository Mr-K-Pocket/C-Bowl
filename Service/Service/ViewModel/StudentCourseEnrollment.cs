using EntityModel.Models;

namespace Service.ViewModel
{
    public class StudentCourseEnrollment
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public Grade? Grade { get; set; }
    }
}
