using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using ProdutoEntity = QuickOrder.Core.Domain.Entities.Produto;

namespace QuickOrder.Core.Application.UseCases.Produto
{
    public class ProdutoCriarUseCase : IProdutoCriarUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoCriarUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ServiceResult> Execute(ProdutoDto produtoViewModel)
        {
            ServiceResult result = new();
            try
            {
                var produto = new ProdutoEntity(produtoViewModel.Nome, (int)ECategoria.Lanche, produtoViewModel.Preco, produtoViewModel.Descricao, produtoViewModel.Foto);
                await _produtoRepository.Insert(produto);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
