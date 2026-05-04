using ITU_ASAU_COLLEGE.Models;
using Microsoft.EntityFrameworkCore;

namespace ITU_ASAU_COLLEGE.Data
{
    public class ITU_ASAU_COLLEGEContext : DbContext
    {
        internal object Student;

        public ITU_ASAU_COLLEGEContext(DbContextOptions<ITU_ASAU_COLLEGEContext> options) : base(options) 
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Notice>().ToTable("Notice");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
        }
    }
}
