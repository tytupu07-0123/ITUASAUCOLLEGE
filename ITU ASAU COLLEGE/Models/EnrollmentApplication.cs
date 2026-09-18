using ITU_ASAU_COLLEGE.Controllers;
using System;
using System.ComponentModel.DataAnnotations;


namespace ITU_ASAU_COLLEGE.Models
{
    public enum ApplicationStatus
    {
        Pending,
        Accepted,
        Rejected
    }

    public class EnrollmentApplication
    {
        public int EnrollmentApplicationId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Year Level")]
        public string YearLevel { get; set; } = string.Empty;

        
        [Required]
        [Display(Name = "Courses")]
        public string Courses { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Parent/Guardian Name")]
        public string ParentGuardianName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [StringLength(1000)]
        [Display(Name = "Additional Information")]
        public string? AdditionalInformation { get; set; }

        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        
    }
}
