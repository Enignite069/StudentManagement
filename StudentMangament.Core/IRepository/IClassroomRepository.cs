using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;

namespace StudentMangament.Core.IRepository
{
    public interface IClassroomRepository : IBaseRepository<Classroom>
    {
        Task<IList<Classroom>> GetClassrooms();
        Task<Classroom> CheckExists(int id);
    }
}
