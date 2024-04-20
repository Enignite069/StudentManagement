using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Service.SubjectService;
using StudentMangament.Core.Models;

namespace StudentManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        private readonly ISubjectServie _subjectServie;

        public SubjectController(ISubjectServie subjectServie)
        {
            _subjectServie = subjectServie;
        }

        // GET: SubjectController
        public async Task<IActionResult> Index()
        {
            return View(await _subjectServie.GetAllSubjects());
        }

        // GET: SubjectController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subject = await _subjectServie.CheckExist(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // GET: SubjectController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                await _subjectServie.AddSubject(subject);
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: SubjectController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _subjectServie.CheckExist(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _subjectServie.EditSubject(subject);
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: SubjectController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _subjectServie.CheckExist(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: SubjectController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _subjectServie.CheckExist(id);
            if (subject != null)
            {
                await _subjectServie.DeleteSubject(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
