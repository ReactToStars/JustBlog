using FA.JustBlog.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.Service.IServices
{
    public interface ICommentService : IBaseService<CommentVM>
    {
        /// <summary>
        /// Get List Post
        /// </summary>
        /// <returns>List Post Item</returns>
        IEnumerable<SelectListItem> GetListPost();
    }
}
