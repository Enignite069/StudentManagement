using Microsoft.EntityFrameworkCore;
using StudentMangament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangament.Core.Data
{
    public static class AppDataInitialiser
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Test",
                    Email = "Test",
                    DoB = Convert.ToDateTime("31/01/2010"),
                    ClassroomId = 1
                }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    Name = "Test",
                    Email = "Test",
                    DoB = Convert.ToDateTime("20/1/2000"),
                    Phone = "0123456789",
                }
            );

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom
                {
                    Id = 1,
                    Name = "Test"
                }
            );
        }
    }
}
