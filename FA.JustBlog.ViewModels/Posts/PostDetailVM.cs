using FA.JustBlog.Core.Models;

namespace FA.JustBlog.ViewModels.Posts
{
    public class PostDetailVM
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }

        public int? ViewCount { get; set; }
        public int? RateCount { get; set; }
        public int? TotalRate { get; set; }
        public decimal? Rate{ get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
