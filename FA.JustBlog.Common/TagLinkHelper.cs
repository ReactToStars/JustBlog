using FA.JustBlog.ViewModels.Tags;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace FA.JustBlog.Common
{
    [HtmlTargetElement(Attributes = nameof(Tags))]
    [HtmlTargetElement("tag-link")]
    public class TagLinkHelper : TagHelper
    {
        public IList<TagVM> Tags { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            var builder = new StringBuilder();

            foreach (var tag in Tags)
            {
                builder.Append($"<a href='/Customer/Post/GetPostsByTag/{tag.TagId}' class='bg-dark text-white px-2 rounded mx-2'>{tag.TagName}</a>");
            }
            output.Content.AppendHtml(builder.ToString());
        }
    }
}