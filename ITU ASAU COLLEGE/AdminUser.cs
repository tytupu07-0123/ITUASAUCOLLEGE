using Microsoft.AspNetCore.Identity;

namespace ITU_ASAU_COLLEGE
{
    public class AdminUser
    {
        public static async Task SeedAdmin(UserManager<IdentityUser> userManager) 
        {
            var email = "admin@ITU_ASAU_COLLEGE.com";

            var adminUser = await userManager.FindByEmailAsync(email);

            if (adminUser == null) 
            {
                adminUser = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "Admin@123");
                await userManager.AddToRoleAsync(adminUser, Constants.Roles.Admin);
            }
        }
    }
}
