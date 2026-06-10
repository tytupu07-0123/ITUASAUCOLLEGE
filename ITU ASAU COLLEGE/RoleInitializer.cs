using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

public static class RoleInitializer 
{
    public static async Task SeedRoles(IServiceProvider serviceProvider)
    {

        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roles =
            {
            "Admin",
            "Teacher",
            "Student"
        };

        foreach (var role in roles) 
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
   
