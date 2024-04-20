using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Service.ClassroomService;
using StudentMangament.Core.IRepository;
using StudentMangament.Core.Models;

namespace StudentManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassroomController : Controller
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        // GET: ClassroomController
        public async Task<IActionResult> Index()
        {
            return View(await _classroomService.GetAllClassrooms());
        }

        // GET: ClassroomController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var classroom = await _classroomService.CheckExist(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return View(classroom);
        }

        // GET: ClassroomController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassroomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                await _classroomService.AddClassroom(classroom);
                return RedirectToAction(nameof(Index));
            }
            return View(classroom);
        }

        // GET: ClassroomController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _classroomService.CheckExist(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return View(classroom);
        }

        // POST: ClassroomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _classroomService.EditClassroom(classroom);
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classroom);
        }

        // GET: ClassroomController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _classroomService.CheckExist(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return View(classroom);
        }

        // POST: ClassroomController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _classroomService.CheckExist(id);
            if (subject != null)
            {
                await _classroomService.DeleteClassroom(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
