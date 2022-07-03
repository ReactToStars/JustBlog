using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories.IRepositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        /// <summary>
        /// Find post by year, month and urlSlug
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Post FindPost(int year, int month, string urlSlug);

        /// <summary>
        /// get posts which are published
        /// </summary>
        /// <returns></returns>
        IList<Post> GetPublishedPosts();

        /// <summary>
        /// get posts which are unpublished
        /// </summary>
        /// <returns></returns>
        IList<Post> GetUnpublishedPosts();

        /// <summary>
        /// Get latest post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetLatestPosts(int size);

        /// <summary>
        /// Get posts by month
        /// </summary>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        IList<Post> GetPostsByMonth(DateTime monthYear);

        /// <summary>
        /// Get number of posts by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int CountPostsForCategory(string category);

        /// <summary>
        /// Get posts by category name
        /// </summary>
        /// <param name="category"></param>
        /// <returns>List Post</returns>
        IList<Post> GetPostsByCategoryName(string category);

        /// <summary>
        /// Get Posts By Category Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List Post</returns>
        IList<Post> GetPostsByCategoryId(int id);

        /// <summary>
        /// Get Posts By Tag Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List Post</returns>
        IList<Post> GetPostsByTagId(int id);

        /// <summary>
        /// Get number of posts by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        int CountPostsForTag(string tag);

        /// <summary>
        /// Get posts by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        IList<Post> GetPostsByTag(string tag);

        /// <summary>
        /// Get most viewed posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetMostViewedPosts(int size);

        /// <summary>
        /// Get highest posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetHighestPosts(int size);

        /// <summary>
        /// Get All Posts
        /// </summary>
        /// <returns></returns>
        IList<Post> GetAll();
    }
}
