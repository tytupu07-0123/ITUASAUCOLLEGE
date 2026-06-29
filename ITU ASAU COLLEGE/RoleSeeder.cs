using Microsoft.AspNetCore.Identity;
using ITU_ASAU_COLLEGE.Constants;

namespace ITU_ASAU_COLLEGE.Constants
{
    public class RoleSeeder
    {
       public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Check if the roles already exist
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }
            if (!await roleManager.RoleExistsAsync(Roles.Teacher))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Teacher));
            }
            if (!await roleManager.RoleExistsAsync(Roles.Student))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Student));
            }
        }
    }
}
