using StudentManagement.ViewModels;
using StudentMangament.Core.Models;

namespace StudentManagement.Service.TeacherService
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task AddTeacher(TeacherCreateVM teacher);
        Task EditTeacher(TeacherCreateVM teacher, int id);
        Task DeleteTeacher(int id);
        Task<Teacher> CheckExist(int id);
    }
}
