using FA.JustBlog.Service.IServices;
using FA.JustBlog.Utility;
using FA.JustBlog.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMIN)]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            var response = _postService.GetAll();
            return View(response.Data);
        }

        public IActionResult Details(int id)
        {
            var response = _postService.GetDetail(id);
            return View(response.Data);
        }

        public IActionResult Create()
        {
            PostCreateVM postCreateVM = new PostCreateVM()
            {
                CategoryList = _postService.GetListCategory()
            };
            return View(postCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostCreateVM postCreateVM)
        {
            var response = _postService.Add(postCreateVM);
            if(response.State == true)
            {
                TempData["success"] = "Post Created Successfuly!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var response = _postService.Find(id);
            if(response.State == true)
            {
                return View(response.Data);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostEditVM postEditVM)
        {
            var response = _postService.Update(postEditVM);
            if(response.State == true)
            {
                TempData["success"] = "Post Updated Successfuly!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var response = _postService.GetDetail(id);
            return View(response.Data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int postId)
        {
            var response = _postService.GetDetail(postId);
            if(response.State == true)
            {
                TempData["success"] = "Post Deleted Successfuly!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View();
            }
        }

        public IActionResult LatestPosts()
        {
            var response = _postService.GetLatestPost(5);
            ViewBag.Title = "List Latest Post";
            return PartialView("_ListPostPartial",response.Data);
        }

        public IActionResult MostViewedPosts()
        {
            var response = _postService.GetMostViewedPosts(5);
            ViewBag.Title = "List Most Viewed Post";
            return PartialView("_ListPostPartial", response.Data);
        }

        public IActionResult PublishedPosts()
        {
            var response = _postService.GetPublishedPosts();
            ViewBag.Title = "List Published Post";
            return PartialView("_ListPostPartial", response.Data);
        }

        public IActionResult UnpublishedPosts()
        {
            var response = _postService.GetUnpublishedPosts();
            ViewBag.Title = "List Unpublished Post";
            return PartialView("_ListPostPartial", response.Data);
        }
    }
}
