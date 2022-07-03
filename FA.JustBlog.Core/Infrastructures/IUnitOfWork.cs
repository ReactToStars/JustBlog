using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Repositories.IRepositories;

namespace FA.JustBlog.Core.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get;}
        public ITagRepository TagRepository { get;}
        public IPostRepository PostRepository { get;}
        public ICommentRepository CommentRepository { get;}
        public IUserRepository UserRepository { get;}
        public JustBlogContext db { get;}
        int SaveChanges();
    }
}
