using FA.JustBlog.ViewModels.Posts;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FA.JustBlog.Common
{
    [HtmlTargetElement (Attributes = nameof(PostIndexVM))]
    [HtmlTargetElement("time-helper")]
    public class TimeHelper : TagHelper
    {
        public PostIndexVM PostIndexVM{ get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "span";
            string builder = "";
            DateTime modified = (DateTime) PostIndexVM.Modified;
            if (DateTime.Compare(PostIndexVM.PostedOn, modified) < 0)
            {
                TimeSpan diff = DateTime.Now.Subtract(modified);
                switch (diff.Days)
                {
                    case 0: 
                        builder = $"<p class='fs-6 my-0'>Modified {modified.ToString("mm")} minutes ago " +
                            $"with rate {PostIndexVM.Rate} by {PostIndexVM.ViewCount} view(s)</p>";
                        break;
                    case 1:
                        builder = $"<p class='fs-6 my-0'>Modified Yesterday at {modified.ToString("h:mm")} " +
                            $"with rate {PostIndexVM.Rate} by {PostIndexVM.ViewCount} view(s)</p>";
                        break;
                    default:
                        builder = $"<p class='fs-6 my-0'>Modified at {modified} " +
                            $"with rate {PostIndexVM.Rate} by {PostIndexVM.ViewCount} view(s)</p>";
                        break;
                }
            }
            else
            {
                TimeSpan diff = DateTime.Now.Subtract(PostIndexVM.PostedOn);
                switch (diff.Days)
                {
                    case 0:
                        builder = $"<p class='fs-6 my-0'>PostedOn {PostIndexVM.PostedOn.ToString("mm")} minutes ago " +
                            $"with rate {PostIndexVM.Rate} by {PostIndexVM.ViewCount} view(s)</p>";
                        break;
                    case 1:
                        builder = $"<p class='fs-6 my-0'>PostedOn Yesterday at {PostIndexVM.PostedOn.ToString("h:mm")} " +
                            $"with rate {PostIndexVM.Rate} by {PostIndexVM.ViewCount} view(s)</p>";
                        break;
                    default:
                        builder = $"<p class='fs-6 my-0'>PostedOn at {PostIndexVM.PostedOn} " +
                            $"with rate {PostIndexVM.Rate} by {PostIndexVM.ViewCount} view(s)</p>";
                        break;
                }
            }
            output.Content.AppendHtml(builder);

        }
        //<p class="fs-6 my-0">Posted @item.PostedOn with rate @item.Rate by @item.ViewCount view(s)</p>
    }
}
