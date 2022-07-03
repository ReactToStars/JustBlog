using FA.JustBlog.Service.IServices;
using FA.JustBlog.Utility;
using FA.JustBlog.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMIN)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var response = _categoryService.GetAll();
            return View(response.Data);
        }

        public IActionResult Details(int id)
        {
            var response = _categoryService.GetDetails(id);
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryVM category)
        {
            var response = _categoryService.Add(category);
            if (response.State == true)
            {
                TempData["success"] = "Category Created Successfuly!";
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
            var response = _categoryService.Find(id);
            if (response.State == true)
            {
                return View(response.Data);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryVM category)
        {
            var response = _categoryService.Update(category);
            if (response.State == true)
            {
                TempData["success"] = "Category Updated Successfuly!";
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
            var response = _categoryService.Find(id);
            return View(response.Data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var response = _categoryService.Delete(categoryId);
            if (response.State == true)
            {
                TempData["success"] = "Category Deleted Successfuly!";
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
