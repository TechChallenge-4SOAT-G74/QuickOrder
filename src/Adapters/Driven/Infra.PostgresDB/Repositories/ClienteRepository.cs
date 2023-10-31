using Microsoft.EntityFrameworkCore;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;
using System.Linq.Expressions;

namespace QuickOrder.Adapters.Driven.PostgresDB.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationContext context) :
            base(context)
        {
        }

        public async Task<List<Cliente>> GetAllClienteComUsuario(Expression<Func<Cliente, bool>> predicate)
        {
            var result = await Queryable().Include(c => c.Usuario)
               .Where(predicate)
               .ToListAsync();
            return result;
        }
    }
}
