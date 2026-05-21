using System.ComponentModel.DataAnnotations;

namespace ITU_ASAU_COLLEGE.Models
{
    public enum CourseName
    {
        English,
        Mathematics,
        Science,
        Biology,
        Chemistry,
        Physics,
        History,
        Geography,
        [Display(Name = "Business Studies")]
        BusinessStudies,
        Accounting,
        Economics,
        [Display(Name = "Social Studies")]
        SocialStudies,
        [Display(Name = "Computer Studies")]
        ComputerStudies,
        [Display(Name = "Health Education")]
        HealthEducation,
        [Display(Name = "Food And Textiles")]
        FoodAndTextiles,
        [Display(Name = "Visual Arts")]
        VisualArts,
        [Display(Name = "Design Technology")]
        DesignTechnology,
        [Display(Name = "Agriculture Science")]
        AgricultureScience,
        [Display(Name = "Samoan Studies")]
        SamoanStudies,
    }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Course Name")]
        public required CourseName CourseName { get; set; }
    }
}
