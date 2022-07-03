﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.ViewModels.Posts
{
    public class PostEditVM
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime? Modified { get; set; } = DateTime.Now;
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }

    }
}
