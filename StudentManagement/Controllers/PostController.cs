using Microsoft.AspNetCore.Mvc;
using StudentManagement.Service.PostService;

namespace StudentManagement.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _postService.GetPublishedPosts();
            return View(model);
        }

        public async Task<IActionResult> Details(int year, int month)
        {
            var model = await _postService.GetPostsDetails(year, month);
            return View(model);
        }
    }
}
