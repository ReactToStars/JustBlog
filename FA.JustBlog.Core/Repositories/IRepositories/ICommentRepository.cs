using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories.IRepositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        /// <summary>
        /// Add an comment
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentName"></param>
        /// <param name="commentEmail"></param>
        /// <param name="commentTitle"></param>
        /// <param name="commentBody"></param>
        void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);

        /// <summary>
        /// Get comments by postId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        IList<Comment> GetCommentsForPost(int postId);

        /// <summary>
        /// Get comments by post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        IList<Comment> GetCommentsForPost(Post post);
    }
}
