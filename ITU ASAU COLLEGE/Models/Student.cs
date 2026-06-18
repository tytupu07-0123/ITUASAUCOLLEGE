using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ITU_ASAU_COLLEGE.Models.Enrollment;

namespace ITU_ASAU_COLLEGE.Models
{
    public enum ClassCode
    {
        [Display(Name = "Yr 9")]
        Yr9,
        [Display(Name = "Yr 10")]
        Yr10,
        [Display(Name = "Yr 11")]
        Yr11,
        [Display(Name = "Yr 12")]
        Yr12,

    }
    public class Student
    {
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        [Display(Name = "Class Code")]
        public ClassCode ClassCode { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required]

        public ICollection<Enrollment>? Enrollments { get; set; }
        

    }


}
