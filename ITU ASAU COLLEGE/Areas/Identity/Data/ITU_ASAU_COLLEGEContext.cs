using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Models;

namespace ITU_ASAU_COLLEGE.Areas.Identity.Data;

public class ITU_ASAU_COLLEGEContext 
    : IdentityDbContext<IdentityUser>
{
    public DbSet<ITU_ASAU_COLLEGE.Models.Result> Result { get; set; } = default!;
    public DbSet<ITU_ASAU_COLLEGE.Models.Attendance> Attendance { get; set; } = default!;
    public ITU_ASAU_COLLEGEContext(DbContextOptions<ITU_ASAU_COLLEGEContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<ITU_ASAU_COLLEGE.Models.Course> Course { get; set; } = default!;

public DbSet<ITU_ASAU_COLLEGE.Models.Enrollment> Enrollment { get; set; } = default!;

public DbSet<ITU_ASAU_COLLEGE.Models.Notice> Notice { get; set; } = default!;

public DbSet<ITU_ASAU_COLLEGE.Models.Student> Student { get; set; } = default!;

public DbSet<ITU_ASAU_COLLEGE.Models.Teacher> Teacher { get; set; } = default!;

public DbSet<ITU_ASAU_COLLEGE.Models.Department> Department { get; set; } = default!;
}
