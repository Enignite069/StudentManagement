using StudentManagement.ViewModels;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;

namespace StudentManagement.Service.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddTeacher(TeacherCreateVM teacher)
        {
            var data = await CheckExist(teacher.Id);
            if (data is not null)
            {
                throw new InvalidOperationException("This Id is already exists");
            }
            Teacher addTeacher = new Teacher 
            { 
                Id = teacher.Id, 
                Name = teacher.Name, 
                YearOfBirth = teacher.YearOfBirth, 
                Gender = (Teacher.GenderChoice)teacher.Gender,
                Subjects = new List<Subject>(),
                Classrooms = new List<Classroom>()
            };
            foreach (var item in teacher.SubjectId) 
            {
                addTeacher.Subjects.Add(new Subject() { Id = item });
            }
            foreach (var item in teacher.ClassroomId)
            {
                addTeacher.Classrooms.Add(new Classroom() { Id = item });
            }
            await _unitOfWork.TeacherRepository.Add(addTeacher);
            await _unitOfWork.SaveChanges();
        }

        public async Task<Teacher> CheckExist(int id)
        {
            return await _unitOfWork.TeacherRepository.CheckExists(id);
        }

        public async Task DeleteTeacher(int id)
        {
            _unitOfWork.TeacherRepository.Delete(id);
            await _unitOfWork.SaveChanges();
        }

        public async Task EditTeacher(TeacherCreateVM teacher, int id)
        {
            var teachers = await _unitOfWork.TeacherRepository.CheckExists(id);
            if (teachers is null)
            {
                throw new InvalidOperationException("The information does not exists");
            }
            teachers.Name = teacher.Name;
            teachers.YearOfBirth = teacher.YearOfBirth;
            teachers.Gender = (Teacher.GenderChoice)teacher.Gender;

            _unitOfWork.TeacherRepository.Update(teachers);
            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _unitOfWork.TeacherRepository.GetTeachers();
        }
    }
}
