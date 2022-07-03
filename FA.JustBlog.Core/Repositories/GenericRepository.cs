using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly JustBlogContext _db;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(JustBlogContext db)
        {
            this._db = db;
            this._dbSet = _db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var existingEntity = _dbSet.Find(id);
            if (existingEntity != null)
                _dbSet.Remove(existingEntity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
