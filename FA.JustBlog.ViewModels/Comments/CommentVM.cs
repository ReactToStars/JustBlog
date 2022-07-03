using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.ViewModels.Comments
{
    public class CommentVM
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; } = DateTime.Now;
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public IEnumerable<SelectListItem> ListPost { get; set; }
    }
}
