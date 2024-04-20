using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Service.TeacherService;
using StudentManagement.ViewModels;
using StudentMangament.Core.Models;

namespace StudentManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this._teacherService = teacherService;
        }


        // GET: TeacherController
        public async Task<IActionResult> Index()
        {
            return View(await _teacherService.GetAllTeachers());
        }

        // GET: TeacherController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = await _teacherService.CheckExist(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }
            var data = new TeacherCreateVM { Id = teacher.Id, Name = teacher.Name, YearOfBirth = teacher.YearOfBirth, Gender = (TeacherCreateVM.GenderChoice)teacher.Gender, SubjectId = (List<int>)teacher.Subjects, ClassroomId = (List<int>)teacher.Classrooms };
            TempData["TeacherId"] = id;
            return View(data);
        }

        // GET: TeacherController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Year of Birth, Gender, Subjects, Classrooms")] TeacherCreateVM teacher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _teacherService.AddTeacher(teacher);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(teacher);
        }

        // GET: TeacherController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = await _teacherService.CheckExist(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }
            var data = new TeacherCreateVM { Name = teacher.Name, YearOfBirth = teacher.YearOfBirth, Gender = (TeacherCreateVM.GenderChoice)teacher.Gender, SubjectId = (List<int>)teacher.Subjects, ClassroomId = (List<int>)teacher.Classrooms };
            TempData["TeacherId"] = id;
            return View(data);
        }


        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name, Year Of Birth, Gender, Subject, Classroom")] TeacherCreateVM teacher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _teacherService.EditTeacher(teacher, id);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            TempData["TeacherId"] = id;
            return View(teacher);
        }

        // GET: TeacherController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = await _teacherService.CheckExist(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: TeacherController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  DeleteConfirmed(int id)
        {
            var teacher = await _teacherService.CheckExist(id);
            if (id != null)
            {
                await _teacherService.DeleteTeacher(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
