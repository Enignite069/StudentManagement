using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Config;
using StudentManagement.Core.Model;

namespace StudentManagement.Core.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=StudentManagement;Trusted_Connection=True;MultipleActiveResultSets=true;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfig).Assembly);

            modelBuilder.SeedData();
        }
    }
}
