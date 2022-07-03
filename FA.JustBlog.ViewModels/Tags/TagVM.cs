namespace FA.JustBlog.ViewModels.Tags
{
    public class TagVM
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public int? Count { get; set; }
    }
}
