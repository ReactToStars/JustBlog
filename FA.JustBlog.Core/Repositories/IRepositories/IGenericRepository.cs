namespace FA.JustBlog.Core.Repositories.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Find an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Find(int id);

        /// <summary>
        /// Change entity state to added
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Change entity state to modified
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Change entity state to deleted
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Change entity state to deleted
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Get all value
        /// </summary>
        /// <returns></returns>
        IList<TEntity> GetAll();
    }
}
