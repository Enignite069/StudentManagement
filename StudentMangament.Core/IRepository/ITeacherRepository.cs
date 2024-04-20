using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;

namespace StudentMangament.Core.IRepository
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        Task<IList<Teacher>> GetTeachers();
        Task<Teacher> CheckExists(int id);
    }
}
