using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Service.ClassroomService;
using StudentManagement.Service.StudentService;
using StudentManagement.ViewModels;
using StudentMangament.Core.IRepository;

namespace StudentManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IClassroomService _classroomService;

        public StudentController(IStudentService studentService, IClassroomService classroomService)
        {
            this._studentService = studentService;
            this._classroomService = classroomService;
        }

        // GET: StudentController
        public async Task<IActionResult> Index()
        {
            var model = await _studentService.GetAllStudents();
            return View(model);
        }
        
        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: StudentController/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["ClassroomId"] = await _classroomService.GetSelectListItems();
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, DateOfBirth, Gender, PhoneNumber, Classroom")] StudentCreateVM student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassroomId"] = await _classroomService.GetSelectListItems();
            return View(student);
        }

        // GET: StudentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.FindStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            var model = new StudentCreateVM();

            model.Name = student.Name;
            model.DateOfBirth = student.DateofBirth;
            model.Gender = (StudentCreateVM.GenderChoice)student.Gender;
            model.Phone = student.PhoneNumber;
            model.ClassroomId = student.ClassroomId;

            ViewData["ClassroomId"] = await _classroomService.GetSelectListItems();
            TempData["StudentId"] = id;
            return View(model);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name, DateOfBirth, Gender, Phone, Classroom")] StudentCreateVM student)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _studentService.EditStudent(student, id);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassroomId"] = await _classroomService.GetSelectListItems();
            TempData["PostId"] = id;
            return View(student);
        }

        // GET: StudentController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.FindStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posts = await _studentService.FindStudentById(id);

            if (posts != null)
            {
                await _studentService.DeleteStudent(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
