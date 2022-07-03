using FA.JustBlog.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Customer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
