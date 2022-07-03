using FA.JustBlog.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Customer.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        

    }
}
