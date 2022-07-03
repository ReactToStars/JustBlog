using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext db) : base(db)
        {
        }

        public IList<Post> GetAll()
        {
            return _db.Posts.Include(x => x.Category).ToList();
            //return _db.Posts.ToList();
        }

        public Post Find(int id)
        {
            return _db.Posts.Include(x => x.Category).SingleOrDefault(x => x.PostId == id);
            //return _db.Posts.Find(id);
        }
        public int CountPostsForCategory(string category)
        {
            return _db.Posts.Count(p => p.Category.CategoryName == category);
        }

        public int CountPostsForTag(string tag)
        {
            return (from p in _db.Posts
                    join pt in _db.PostTagMaps on p.PostId equals pt.PostId
                    join t in _db.Tags on pt.TagId equals t.TagId
                    where t.TagName == tag
                    select p.PostId).Count();
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return _db.Posts.Include(p => p.Category).FirstOrDefault(p => p.PostedOn.Year.Equals(year)
                    && p.PostedOn.Month.Equals(month) && p.UrlSlug.Equals(urlSlug));
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return _db.Posts.Include(p => p.Category).OrderByDescending(p => p.Rate).Take(size).ToList();
        }

        public IList<Post> GetLatestPosts(int size)
        {
            return _db.Posts.Include(p => p.Category).OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }

        public IList<Post> GetMostViewedPosts(int size)
        {
            return _db.Posts.Include(p => p.Category).OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetPostsByCategoryName(string category)
        {
            return _db.Posts.Where(p => p.Category.CategoryName.Equals(category)).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _db.Posts.Where(p => p.PostedOn.Month.Equals(monthYear.Month)).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return (from p in _db.Posts
                    join pt in _db.PostTagMaps on p.PostId equals pt.PostId
                    join t in _db.Tags on pt.TagId equals t.TagId
                    where t.TagName == tag
                    select p).ToList();
        }

        public IList<Post> GetPublishedPosts()
        {
            return _db.Posts.Where(p => p.Published == true).ToList();
        }

        public IList<Post> GetUnpublishedPosts()
        {
            return _db.Posts.Where(p => p.Published == false).ToList();
        }

        public IList<Post> GetPostsByCategoryId(int id)
        {
            return _db.Posts.Where(p => p.CategoryId == id).ToList();
        }

        public IList<Post> GetPostsByTagId(int id)
        {
            return (from p in _db.Posts
                    join pt in _db.PostTagMaps on p.PostId equals pt.PostId
                    join t in _db.Tags on pt.TagId equals t.TagId
                    where t.TagId == id
                    select p).ToList();
        }
    }
}
