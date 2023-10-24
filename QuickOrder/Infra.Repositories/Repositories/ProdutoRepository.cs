using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Core;

namespace Infra.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) :
            base(context)
        {
        }

    }
}
