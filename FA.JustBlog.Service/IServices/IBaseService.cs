namespace FA.JustBlog.Service.IServices
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Find an Entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TEntity</returns>
        ResponseResult<TEntity> Find(int id);

        /// <summary>
        /// Change entity state to added
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ResponseResult</returns>
        ResponseResult<TEntity> Add(TEntity entity);

        /// <summary>
        /// Change entity state to modified
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ResponseResult</returns>
        ResponseResult<TEntity> Update(TEntity entity);

        /// <summary>
        /// Change entity state to deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResponseResult</returns>
        ResponseResult<TEntity> Delete(int id);

        /// <summary>
        /// Change entity state to deleted
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ResponseResult</returns>
        ResponseResult<TEntity> Delete(TEntity entity);

        /// <summary>
        /// Get all value
        /// </summary>
        /// <returns>List of Entity</returns>
        ResponseResult<IList<TEntity>> GetAll();
    }
}
