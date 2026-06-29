using Microsoft.AspNetCore.Identity;

namespace ITU_ASAU_COLLEGE
{
    public class AdminUser
    {
        public static async Task SeedAdmin(UserManager<IdentityUser> userManager) 
        {
            string email = "admin@ITU_ASAU_COLLEGE.com";

            var user = await userManager.FindByEmailAsync(email);

            if (user == null) 
            {
                user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Constants.Roles.Admin);
            }
        }
    }
}
