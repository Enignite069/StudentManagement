using Microsoft.EntityFrameworkCore;
using StudentMangament.Core.Data;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.IRepository;
using StudentMangament.Core.Models;

namespace StudentMangament.Core.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Student> FindStudent(int id)
        {
            return await _DbContext.Students.Include(it => it.Classroom).FirstOrDefaultAsync(it => it.Id.Equals(id));
        }

        public async Task<IList<Student>> GetAllStudents()
        {
            return await _DbContext.Students.Include(it => it.Classroom).ToListAsync();
        }

        public async Task<IList<Student>> GetStudentsByClassroom(string classroom)
        {
            return await _DbContext.Students.Where(it => it.Classroom.Name.Equals(classroom)).ToListAsync();
        }

        public async Task<IList<Student>> GetStudentsByYear(DateTime year)
        {
            return await _DbContext.Students.Where(it => it.DateofBirth.Year == year.Year).ToListAsync();
        }
    }
}
