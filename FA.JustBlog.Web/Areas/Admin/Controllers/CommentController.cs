using FA.JustBlog.Service.IServices;
using FA.JustBlog.Utility;
using FA.JustBlog.ViewModels.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMIN)]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            var response = _commentService.GetAll();
            return View(response.Data);
        }

        public IActionResult Details(int id)
        {
            var response = _commentService.Find(id);
            return View(response.Data);
        }

        public IActionResult Create()
        {
            CommentVM commentVM = new CommentVM()
            {
                ListPost = _commentService.GetListPost()
            };
            return View(commentVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommentVM Comment)
        {
            var response = _commentService.Add(Comment);
            if (response.State == true)
            {
                TempData["success"] = "Comment Created Successfuly!";
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
            var response = _commentService.Find(id);
            if (response.State == true)
            {
                return View(response.Data);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CommentVM Comment)
        {
            var response = _commentService.Update(Comment);
            if (response.State == true)
            {
                TempData["success"] = "Comment Updated Successfuly!";
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
            var response = _commentService.Find(id);
            return View(response.Data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteComment(int CommentId)
        {
            var response = _commentService.Delete(CommentId);
            if (response.State == true)
            {
                TempData["success"] = "Comment Deleted Successfuly!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View();
            }
        }
    }
}
