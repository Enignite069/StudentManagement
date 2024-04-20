using Microsoft.EntityFrameworkCore;
using StudentMangament.Core.Data;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.IRepository;
using StudentMangament.Core.Models;

namespace StudentMangament.Core.Repository
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Teacher> CheckExists(int id)
        {
            return await _DbContext.Teachers.FirstOrDefaultAsync(it => it.Id.Equals(id));
        }

        public async Task<IList<Teacher>> GetTeachers()
        {
            return await _DbContext.Teachers.ToListAsync();
        }
    }
}
