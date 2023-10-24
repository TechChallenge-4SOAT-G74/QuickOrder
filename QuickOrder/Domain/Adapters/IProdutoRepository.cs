using Domain.Adapters;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProdutoRepository : IBaseRepository, IRepository<Produto>
    {
    }
}
