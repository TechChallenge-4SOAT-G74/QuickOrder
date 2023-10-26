namespace QuickOrder.Core.Domain.Adapters
{
    public interface IBaseMongoDBRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(string id);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();

    }
}
