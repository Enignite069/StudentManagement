using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Model;

namespace StudentManagement.Core.Data
{
    public static class AppDataInitializer
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    StudentName = "Hung Anh",
                    StudentEmail = "hunganh@gmail.com",
                    StudentDoB = Convert.ToDateTime("2002/09/06"),
                    StudentAddress = "Hien Thanh"
                }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    TeacherId = 1,
                    TeacherName = "Loan"
                }
            );

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom
                {
                    ClassroomId = 1,
                    ClassroomName = "6A"
                }
            );
        }
    }
}
