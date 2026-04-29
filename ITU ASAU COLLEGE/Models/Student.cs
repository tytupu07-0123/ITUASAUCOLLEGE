using System.ComponentModel.DataAnnotations;
using static ITU_ASAU_COLLEGE.Models.Enrollment;

namespace ITU_ASAU_COLLEGE.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfEnrollment { get; set; }
        public int ClassCode { get; set; }
        //Data Annotations to only allow "Yr 9, Yr 10, Yr 11, Yr 12" in the ClassCode property
        public int CourseId { get; set; }
        public DateTime DateOfBirth { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy")]
        [Required]

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}



