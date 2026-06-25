using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ITU_ASAU_COLLEGE.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? Position { get; set; }

        public string? Department { get; set; }
    }
}