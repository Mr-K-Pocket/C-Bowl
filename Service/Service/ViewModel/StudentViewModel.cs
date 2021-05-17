using System;

namespace Service.ViewModel
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public StudentViewModel()
        {
            EnrollmentDate = DateTime.Now;
        }
    }
}
