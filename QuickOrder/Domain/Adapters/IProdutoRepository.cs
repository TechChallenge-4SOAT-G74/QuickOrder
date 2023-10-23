using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProdutoRepository : IBaseRepository
    {
        Task Add(Produto produto);
        Task Update(Produto produto);
        Task Delete(Guid id);
        Task<Produto> GetById(Guid Id);
        Task<Produto> GetAll();
    }
}
