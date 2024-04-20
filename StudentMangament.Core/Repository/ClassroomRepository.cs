using Microsoft.EntityFrameworkCore;
using StudentMangament.Core.Data;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.IRepository;
using StudentMangament.Core.Models;

namespace StudentMangament.Core.Repository
{
    public class ClassroomRepository : BaseRepository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Classroom> CheckExists(int id)
        {
            return await _DbContext.Classrooms.FirstOrDefaultAsync(it => it.Id.Equals(id));
        }

        public async Task<IList<Classroom>> GetClassrooms()
        {
            return await _DbContext.Classrooms.ToListAsync();
        }
    }
}
