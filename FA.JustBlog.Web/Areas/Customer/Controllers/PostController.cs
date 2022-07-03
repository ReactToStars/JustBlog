using FA.JustBlog.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public PostController(IPostService postService, ICategoryService categoryService, ITagService tagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "All Post";
            var response = _postService.GetAll();
            return PartialView("_ListPostPartial" ,response.Data);
        }

        public IActionResult MostViewedPost(int size)
        {
            ViewBag.Title = "Most Viewed Post";
            var response = _postService.GetMostViewedPosts(size);
            return PartialView("_ListPostPartial", response.Data);
        }

        public IActionResult LatestPosts(int size)
        {
            ViewBag.Title = "Latest Posts";
            var response = _postService.GetLatestPost(size);
            return PartialView("_ListPostPartial", response.Data);
        }

        public IActionResult Details(int year, int month, string title)
        {
            var response = _postService.FindPost(year, month, title);
            return View(response.Data);
        }

        public IActionResult GetPostsByCategory(int id)
        {
            ViewBag.Title = _categoryService.Find(id).Data.CategoryName;
            var response = _postService.GetPostsByCategoryId(id);
            return PartialView("_ListPostPartial", response.Data);
        }

        public IActionResult GetPostsByTag(int id)
        {
            ViewBag.Title = "List Post By " + _tagService.Find(id).Data.TagName;
            var response = _postService.GetPostsByTagId(id);
            return PartialView("_ListPostPartial", response.Data);
        }
    }
}
