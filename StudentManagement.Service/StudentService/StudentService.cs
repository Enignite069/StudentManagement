using StudentManagement.ViewModels;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;

namespace StudentManagement.Service.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddStudent(StudentCreateVM student)
        {
            var students = new Student
            {
                Id = student.Id,
                Name = student.Name,
                DateofBirth = student.DateOfBirth,
                Gender = (Student.GenderChoice)student.Gender,
                PhoneNumber = student.Phone,
                ClassroomId = student.ClassroomId
            };
            await _unitOfWork.StudentRepository.Add(students);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteStudent(int studentId)
        {
            _unitOfWork.StudentRepository.Delete(studentId);
            await _unitOfWork.SaveChanges();
        }

        public async Task EditStudent(StudentCreateVM student, int id)
        {
            var data = await _unitOfWork.StudentRepository.FindStudent(id);
            if (data is null)
            {
                throw new InvalidOperationException("The Student doesn't exists");
            }
            data.Name = student.Name;
            data.DateofBirth = student.DateOfBirth;
            data.Gender = (Student.GenderChoice)student.Gender;
            data.PhoneNumber = student.Phone;
            data.ClassroomId = student.ClassroomId;
            _unitOfWork.StudentRepository.Update(data);
            await _unitOfWork.SaveChanges();
        }

        public async Task<Student> FindStudentById(int studentId)
        {
            return await _unitOfWork.StudentRepository.FindStudent(studentId);
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _unitOfWork.StudentRepository.GetAllStudents();
        }

        public async Task<IEnumerable<Student>> GetStudentsByClassroom(string classroom)
        {
            return await _unitOfWork.StudentRepository.GetStudentsByClassroom(classroom);
        }
    }
}
