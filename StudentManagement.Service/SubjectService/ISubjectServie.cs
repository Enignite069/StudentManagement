using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMangament.Core.Models;

namespace StudentManagement.Service.SubjectService
{
    public interface ISubjectServie
    {
        Task<IEnumerable<Subject>> GetAllSubjects();
        Task<IEnumerable<SelectListItem>> GetSelectListItems();
        Task<Subject> CheckExist(int id);
        Task AddSubject(Subject subject);
        Task EditSubject(Subject subject);
        Task DeleteSubject(int subjectId);
    }
}
