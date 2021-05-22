using DapperService.Enum;

namespace DapperService.Model
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
    }
}
