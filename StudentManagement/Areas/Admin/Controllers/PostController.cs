using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Service.PostService;
using StudentManagement.ViewModels;

namespace StudentManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        // GET: PostController
        public async Task<IActionResult> Index()
        {
            var model = await _postService.GetAllPosts();
            return View(model);
        }

        public async Task<IActionResult> Published()
        {
            var model = await _postService.GetPublishedPosts();
            return View(model);
        }

        public async Task<IActionResult> Unpublished()
        {
            var model = await _postService.GetUnpublishedPosts();
            return View(model);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public async Task<IActionResult> CreateAsync()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ShortDescription,Published,PostContent")] PostCreateVM posts)
        {
            if (ModelState.IsValid)
            {
                await _postService.AddPost(posts);
                return RedirectToAction(nameof(Index));
            }
            return View(posts);
        }

        // GET: PostController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _postService.FindPostById(id);
            if (posts == null)
            {
                return NotFound();
            }

            var model = new PostCreateVM();

            model.Title = posts.Title;
            model.ShortDescription = posts.ShortDescription;
            model.Published = posts.Published;
            model.PostContent = posts.PostContent;

            TempData["PostId"] = id;
            return View(model);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,ShortDescription,Published,PostContent")] PostCreateVM posts)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _postService.EditPost(posts, id);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["PostId"] = id;
            return View(posts);
        }

        // GET: PostController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _postService.FindPostById(id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posts = await _postService.FindPostById(id);

            if (posts != null)
            {
                await _postService.DeletePost(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
