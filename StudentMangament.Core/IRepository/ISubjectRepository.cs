using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;

namespace StudentMangament.Core.IRepository
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Task<IList<Subject>> GetSubjects();
        Task<Subject> CheckExists(int id);
    }
}
