using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentMangament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangament.Core.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=StudentManagement;Trusted_Connection=True;MultipleActiveResultSets=true;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedData();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
    }
}
