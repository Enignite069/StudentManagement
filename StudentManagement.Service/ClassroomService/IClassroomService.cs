using StudentMangament.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Service.ClassroomService
{
    public interface IClassroomService
    {
        Task<IEnumerable<Classroom>> GetAllClassrooms();
        Task<IEnumerable<SelectListItem>> GetSelectListItems();
        Task<Classroom> CheckExist(int id);
        Task AddClassroom(Classroom classroom);
        Task EditClassroom(Classroom classroom);
        Task DeleteClassroom(int classroomId);
    }
}
