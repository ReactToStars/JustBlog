using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.IRepositories;

namespace FA.JustBlog.Core.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext db):base(db)
        {
        }

        public IList<Tag> GetPopularTags(int size)
        {
            return _db.Tags.OrderByDescending(t => t.Count).Take(size).ToList();
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _db.Tags.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }

        public IList<Tag> GetTagsByPost(int postId)
        {
            return (from t in _db.Tags
                    join pt in _db.PostTagMaps on t.TagId equals pt.TagId
                    join p in _db.Posts on pt.PostId equals p.PostId
                    where p.PostId == postId
                    select t).ToList();
        }
    }
}
