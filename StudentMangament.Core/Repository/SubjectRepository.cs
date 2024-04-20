using Microsoft.EntityFrameworkCore;
using StudentMangament.Core.Data;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.IRepository;
using StudentMangament.Core.Models;

namespace StudentMangament.Core.Repository
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Subject> CheckExists(int id)
        {
            return await _DbContext.Subjects.FirstOrDefaultAsync(it => it.Id.Equals(id));
        }

        public async Task<IList<Subject>> GetSubjects()
        {
            return await _DbContext.Subjects.ToListAsync();
        }
    }
}
