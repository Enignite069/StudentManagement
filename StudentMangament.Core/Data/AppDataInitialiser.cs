using Microsoft.EntityFrameworkCore;
using StudentMangament.Core.Models;

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
                    DateofBirth = Convert.ToDateTime("31/01/2010"),
                    Gender = Student.GenderChoice.Male,
                    PhoneNumber = "0123456789",
                    ClassroomId = 1
                },
                new Student
                {
                    Id = 2,
                    Name = "Truong Mai An",
                    DateofBirth = Convert.ToDateTime("26/02/2012"),
                    Gender = Student.GenderChoice.Female,
                    PhoneNumber = "0974172372",
                    ClassroomId = 2
                },
                new Student
                {
                    Id = 3,
                    Name = "Nguyen Thi Hong Anh",
                    DateofBirth = Convert.ToDateTime("01/06/2012"),
                    Gender = Student.GenderChoice.Female,
                    PhoneNumber = "0768302645",
                    ClassroomId = 2
                },
                new Student
                {
                    Id = 4,
                    Name = "Tran Hoang Anh",
                    DateofBirth = Convert.ToDateTime("30/06/2012"),
                    Gender = Student.GenderChoice.Male,
                    PhoneNumber = "0365757462",
                    ClassroomId = 2
                }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    Name = "Test",
                    YearOfBirth = 2023,
                    Gender = Teacher.GenderChoice.Male,
                },
                new Teacher
                {
                    Id = 2,
                    Name = "Nguyen Thi Bich Ngoc",
                    YearOfBirth = 1973,
                    Gender = Teacher.GenderChoice.Female,
                },
                new Teacher
                {
                    Id = 3,
                    Name = "Nguyen Thi Phuong",
                    YearOfBirth = 1978,
                    Gender = Teacher.GenderChoice.Female,
                },
                new Teacher
                {
                    Id = 4,
                    Name = "Nguyen Thang Khoa",
                    YearOfBirth = 1980,
                    Gender = Teacher.GenderChoice.Male,
                }
            );

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom
                {
                    Id = 1,
                    Name = "Test"
                },
                new Classroom
                {
                    Id = 2,
                    Name = "6A"
                },
                new Classroom
                {
                    Id = 3,
                    Name = "6B"
                },
                new Classroom
                {
                    Id = 4,
                    Name = "6C"
                }
            );

            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "Test"
                }
            );
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Published Test",
                    ShortDescription = "This is Test for Published Post",
                    Published = true,
                    PostedOn = DateTime.Now,
                    PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },
                new Post
                {
                    Id = 2,
                    Title = "Unpublished Test",
                    ShortDescription = "This is Test for Unpublished Post",
                    Published = false,
                    PostedOn = DateTime.Now,
                    PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                }
            );
        }
    }
}
