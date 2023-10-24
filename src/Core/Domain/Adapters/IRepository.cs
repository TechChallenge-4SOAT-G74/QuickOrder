using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Core.Domain.Adapters
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> Get();
        Task<T> GetById(object id);
        Task<T> Insert(T entity);
        Task<List<T>> Insert(List<T> entities);
        Task<T> Update(T entity);
        Task<List<T>> Update(List<T> entities);
        Task<T> Disable(T entity);
        Task<List<T>> Disable(List<T> entities);
        Task Delete(object id);
        Task DeleteRange(object[] ids);
    }
}
