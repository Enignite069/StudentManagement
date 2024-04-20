using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;

namespace StudentManagement.Service.ClassroomService
{
    public class ClassroomService : IClassroomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassroomService(IUnitOfWork unitOfWork) 
        { 
            this._unitOfWork = unitOfWork;
        }

        public async Task AddClassroom(Classroom classroom)
        {
            await _unitOfWork.ClassroomRepository.Add(classroom);
            await _unitOfWork.SaveChanges();
        }

        public async Task<Classroom> CheckExist(int id)
        {
            return await _unitOfWork.ClassroomRepository.CheckExists(id);
        }

        public async Task DeleteClassroom(int classroomId)
        {
           _unitOfWork.ClassroomRepository.Delete(classroomId);
            await _unitOfWork.SaveChanges();
        }

        public async Task EditClassroom(Classroom classroom)
        {
            _unitOfWork.ClassroomRepository.Update(classroom);
            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<Classroom>> GetAllClassrooms()
        {
            return await _unitOfWork.ClassroomRepository.GetClassrooms();
        }

        public async Task<IEnumerable<SelectListItem>> GetSelectListItems()
        {
            return (await _unitOfWork.ClassroomRepository.GetClassrooms()).Select(it => new SelectListItem() { Text = it.Name, Value = it.Id.ToString() });
        }
    }
}