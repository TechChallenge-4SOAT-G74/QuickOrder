using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Core.Domain.Repositories
{
    public interface IClienteRepository : IBaseRepository, IRepository<Cliente>
    {
    }
}
