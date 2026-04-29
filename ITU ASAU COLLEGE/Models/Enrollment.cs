using System.ComponentModel.DataAnnotations;

namespace ITU_ASAU_COLLEGE.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public required string CourseName { get; set; }
        //Data Annotations to only allow "English, Communication English, Mathematics, Genegal Mathematics,Science, Biology,Chemistry, Pysics, History, Geography, Business Studies, Accounting, Economics, Social Studies, Computer Studies, Health Education, Food And Textiles, Visual Arts, Design Technology, Agriculture Science, Samoan" in the CourseName property
        [Display(Name = "If Yr 9 enter only a max of 8 subjects or else enter only 6 subjects")]
        public required string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public int Class { get; set; }
        //Data Annotations to only allow "Yr 9, Yr 10, Yr 11, Yr 12" in the Class property
        public ICollection<Student>? Student { get; set; }
        public ICollection<Course>? Course { get; set; }

    }
}
