using StudentMangament.Core.Data;
using StudentMangament.Core.IRepository;
using StudentMangament.Core.Repository;

namespace StudentMangament.Core.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IClassroomRepository _classroomRepository;
        private IStudentRepository _studentRepository;
        private ISubjectRepository _subjectRepository;
        private ITeacherRepository _teacherRepository;
        private IPostRepository _postRepository;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }
            
        public AppDbContext AppDbContext => _context;
        public IClassroomRepository ClassroomRepository => _classroomRepository ?? (_classroomRepository = new ClassroomRepository(_context));

        public IStudentRepository StudentRepository => _studentRepository ?? (_studentRepository = new StudentRepository(_context));

        public ISubjectRepository SubjectRepository => _subjectRepository ?? (_subjectRepository = new SubjectRepository(_context));

        public ITeacherRepository TeacherRepository => _teacherRepository ?? (_teacherRepository = new TeacherRepository(_context));

        public IPostRepository PostRepository => _postRepository ?? (_postRepository = new PostRepository(_context));

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
