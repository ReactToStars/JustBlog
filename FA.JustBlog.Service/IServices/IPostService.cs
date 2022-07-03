using FA.JustBlog.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.Service.IServices
{
    public interface IPostService
    {
        /// <summary>
        /// Find an Entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Post</returns>
        ResponseResult<PostEditVM> Find(int id);

        /// <summary>
        /// Change entity state to added
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ResponseResult</returns>
        ResponseResult<PostCreateVM> Add(PostCreateVM postCreateVM);

        /// <summary>
        /// Change entity state to modified
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ResponseResult</returns>
        ResponseResult<PostEditVM> Update(PostEditVM postEditVM);

        /// <summary>
        /// Change entity state to deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseResult</returns>
        ResponseResult<PostEditVM> Delete(int id);

        /// <summary>
        /// Change entity state to deleted
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ResponseResult</returns>
        ResponseResult<PostEditVM> Delete(PostEditVM postIndexVM);

        /// <summary>
        /// Get all value
        /// </summary>
        /// <returns>List of Entity</returns>
        ResponseResult<IList<PostIndexVM>> GetAll();

        /// <summary>
        /// Return List of Category
        /// </summary>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetListCategory();

        /// <summary>
        /// Get Detail of Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PostDetailVM</returns>
        ResponseResult<PostDetailVM> GetDetail(int id);

        /// <summary>
        /// Get Latest Posts And Sorting them by descending
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        ResponseResult<IList<PostIndexVM>> GetLatestPost(int size);

        /// <summary>
        /// Get Most Viewed Posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        ResponseResult<IList<PostIndexVM>> GetMostViewedPosts(int size);

        /// <summary>
        /// Get Posts by Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List Post</returns>
        ResponseResult<IList<PostIndexVM>> GetPostsByCategoryId(int id);

        /// <summary>
        /// Get Posts By TagId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List Post</returns>
        ResponseResult<IList<PostIndexVM>> GetPostsByTagId(int id);

        /// <summary>
        /// Find Post by year, month and urlSlug
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns>Post</returns>
        ResponseResult<PostDetailVM> FindPost(int year, int month, string urlSlug);

        /// <summary>
        /// Get List Interesting Posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns>List Post</returns>
        ResponseResult<IList<PostIndexVM>> GetInterestingPosts(int size);

        /// <summary>
        /// Get Puslished Posts
        /// </summary>
        /// <returns>List Posts</returns>
        ResponseResult<IList<PostIndexVM>> GetPublishedPosts();

        /// <summary>
        /// Get Unpublished Post
        /// </summary>
        /// <returns>List Post</returns>
        ResponseResult<IList<PostIndexVM>> GetUnpublishedPosts();


    }
}
