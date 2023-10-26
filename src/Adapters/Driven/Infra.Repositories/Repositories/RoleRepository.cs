using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Adapters.Driven.PostgresDB.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) :
            base(context)
        {
        }

    }
}
