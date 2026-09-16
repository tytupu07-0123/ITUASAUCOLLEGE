using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using ITU_ASAU_COLLEGE.Models;

public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("ITU_ASAU_COLLEGEContextConnection") ?? throw new InvalidOperationException("Connection string 'ITU_ASAU_COLLEGEContextConnection' not found."); ;

        builder.Services.AddDbContext<ITU_ASAU_COLLEGEContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ITU_ASAU_COLLEGEContext>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        
        var app = builder.Build();

        // Seed the database.
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            
                var context = services.GetRequiredService<ITU_ASAU_COLLEGEContext>();
                DbInitializer.Initialize(context);
        }
        

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        

        app.MapStaticAssets();
        app.MapRazorPages();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();
        app.UseAuthorization();
        

        app.MapStaticAssets();
        app.MapRazorPages();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new List<string> { "Admin", "Teacher", "Student" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

        }
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string FirstName = "Admin";
            string LastName = "IAC";
            DateTime DateOfBirth = new DateTime(2000, 1, 1);
            string email = "admin@IAC.edu.ws";
            string password = "Password123!";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    
                };

                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Admin");
                await userManager.AddToRoleAsync(user, "Teacher");
                await userManager.AddToRoleAsync(user, "Student");
            }
            ;


            

        }
        app.Run();
    }

   
}