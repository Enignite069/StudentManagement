using Microsoft.AspNetCore.Mvc;
using StudentManagement.Service.StudentService;

namespace StudentManagement.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly IStudentService _studentService;

        public ClassroomController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        public async Task<IActionResult> Index(string classroom)
        {
            //var model = await _studentService.GetStudentsByClassroom(classroom);
            var model = await _studentService.GetAllStudents();
            TempData["catName"] = classroom;
			return View(model);
    }
    }
}
