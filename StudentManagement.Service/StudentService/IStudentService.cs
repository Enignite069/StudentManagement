using StudentManagement.ViewModels;
using StudentMangament.Core.Models;

namespace StudentManagement.Service.StudentService
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<IEnumerable<Student>> GetStudentsByClassroom(string classroom);
        Task AddStudent(StudentCreateVM student);
        Task EditStudent(StudentCreateVM student, int id);
        Task DeleteStudent(int studentId);

        Task<Student> FindStudentById(int studentId);
    }
}
