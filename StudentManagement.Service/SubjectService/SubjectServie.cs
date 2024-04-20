using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;

namespace StudentManagement.Service.SubjectService
{
    public class SubjectService : ISubjectServie
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddSubject(Subject subject)
        {
            await _unitOfWork.SubjectRepository.Add(subject);
            await _unitOfWork.SaveChanges();
        }

        public async Task<Subject> CheckExist(int id)
        {
            return await _unitOfWork.SubjectRepository.CheckExists(id);
        }

        public async Task DeleteSubject(int subjectId)
        {
            _unitOfWork.SubjectRepository.Delete(subjectId);
            await _unitOfWork.SaveChanges();
        }

        public async Task EditSubject(Subject subject)
        {
            _unitOfWork.SubjectRepository.Update(subject);
            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await _unitOfWork.SubjectRepository.GetSubjects();
        }

        public async Task<IEnumerable<SelectListItem>> GetSelectListItems()
        {
            return (await _unitOfWork.SubjectRepository.GetSubjects()).Select(it => new SelectListItem() { Text = it.Name, Value = it.Id.ToString() });
        }
    }
}
