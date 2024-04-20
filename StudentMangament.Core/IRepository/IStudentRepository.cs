using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;

namespace StudentMangament.Core.IRepository
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IList<Student>> GetAllStudents();
        Task<IList<Student>> GetStudentsByYear(DateTime year);
        Task<IList<Student>> GetStudentsByClassroom(string classroom);
        Task<Student> FindStudent(int id);
    }
}
