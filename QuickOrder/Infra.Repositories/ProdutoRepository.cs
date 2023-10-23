using Domain.Entities;
using Domain.Repositories;
using MongoDB.Driver;

namespace Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMongoCollection<Produto> _produtoCollection;
        public ProdutoRepository(IMongoDatabase mongoDatabase)
        {
            _produtoCollection = mongoDatabase.GetCollection<Produto>("produto");

        }

        public async Task Add(Produto produto)
        {
            try
            {
                await _produtoCollection.InsertOneAsync(produto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  
            }
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }



        public Task Update(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
