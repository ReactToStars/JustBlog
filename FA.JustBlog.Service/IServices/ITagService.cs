using FA.JustBlog.ViewModels.Tags;

namespace FA.JustBlog.Service.IServices
{
    public interface ITagService : IBaseService<TagVM>
    {
        /// <summary>
        /// Get Popular Tags
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        ResponseResult<IList<TagVM>> GetPopularTags(int size);

        /// <summary>
        /// Get Tags By Post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        ResponseResult<IList<TagVM>> GetTagsByPost(int postId);
    }
}
