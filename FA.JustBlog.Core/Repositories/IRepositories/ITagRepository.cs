using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories.IRepositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        /// <summary>
        /// Get a tag by an urlSlug
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Tag GetTagByUrlSlug(string urlSlug);

        /// <summary>
        /// Get Popular Tags
        /// </summary>
        /// <returns></returns>
        IList<Tag> GetPopularTags(int size);
        
        /// <summary>
        /// Get Tags by Post Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>List Tags</returns>
        IList<Tag> GetTagsByPost(int postId);
    }
}
