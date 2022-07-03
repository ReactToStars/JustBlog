using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext db):base(db)
        {

        }

        public Comment Find(int id)
        {
            return _db.Comments.Include(c => c.Post).FirstOrDefault(c => c.CommentId == id);
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment();
            comment.PostId = postId;
            comment.Name = commentName;
            comment.Email = commentEmail;
            comment.CommentHeader = commentTitle;
            comment.CommentText = commentBody;
            _dbSet.Add(comment);
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return _dbSet.Where(c => c.PostId == postId).ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return _dbSet.Where(c => c.Post == post).ToList();
        }
    }
}
