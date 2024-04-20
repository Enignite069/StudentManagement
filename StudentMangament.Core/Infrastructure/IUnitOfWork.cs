using StudentMangament.Core.Data;
using StudentMangament.Core.IRepository;

namespace StudentMangament.Core.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        public IClassroomRepository ClassroomRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public ITeacherRepository TeacherRepository { get; }
        public IPostRepository PostRepository { get; }
        public AppDbContext AppDbContext { get; }
        Task<int> SaveChanges();
    }
}
