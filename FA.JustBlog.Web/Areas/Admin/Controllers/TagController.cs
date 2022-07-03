using FA.JustBlog.Service.IServices;
using FA.JustBlog.Utility;
using FA.JustBlog.ViewModels.Tags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMIN)]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        public IActionResult Index()
        {
            var response = _tagService.GetAll();
            return View(response.Data);
        }

        public IActionResult Details(int id)
        {
            var response = _tagService.Find(id);
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TagVM tag)
        {
            var response = _tagService.Add(tag);
            if(response.State == true)
            {
                TempData["success"] = "Tag Created Successfuly!";
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
            var response = _tagService.Find(id);
            if(response.State == true)
            {
                return View(response.Data);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TagVM tag)
        {
            var response = _tagService.Update(tag);
            if(response.State == true)
            {
                TempData["success"] = "Tag Updated Successfuly!";
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
            var response = _tagService.Find(id);
            return View(response.Data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteTag(int TagId)
        {
            var response = _tagService.Delete(TagId);
            if(response.State == true)
            {
                TempData["success"] = "Tag Deleted Successfuly!";
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
