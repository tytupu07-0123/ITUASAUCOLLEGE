using static ITU_ASAU_COLLEGE.Models.Enrollment;

namespace ITU_ASAU_COLLEGE.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public int ClassCode { get; set; }
        //Data Annotations to only allow "Yr 9, Yr 10, Yr 11, Yr 12" in the ClassCode property
        public required string Subjects { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Village { get; set; }

        public required ICollection<Enrollment> Enrollments { get; set; }

    }
}

