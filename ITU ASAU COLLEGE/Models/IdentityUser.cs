using Microsoft.AspNetCore.Identity;

namespace ITU_ASAU_COLLEGE.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? ProfilePicture { get; set; }
    }
}