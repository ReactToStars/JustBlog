using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Core.Repositories.IRepositories;

namespace FA.JustBlog.Core.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _db;
        private ICategoryRepository _categoryRepository;
        private ITagRepository _tagRepository;
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(JustBlogContext db)
        {
            _db = db;
        }

        public ICategoryRepository CategoryRepository
        {
            get { 
                if(_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_db); 
                return _categoryRepository;
            }
        }

        public ITagRepository TagRepository => _tagRepository ?? (_tagRepository = new TagRepository(_db));

        public IPostRepository PostRepository => _postRepository ?? (_postRepository = new PostRepository(_db));

        public ICommentRepository CommentRepository => _commentRepository ?? (_commentRepository = new CommentRepository(_db));
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_db));

        public JustBlogContext db => _db;

        public void Dispose()
        {
            _db.Dispose();
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}
