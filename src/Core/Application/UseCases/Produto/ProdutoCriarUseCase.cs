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
            var produto = new ProdutoEntity { Nome = produtoViewModel.Nome, CategoriaId = (int)ECategoria.Lanche, Preco = produtoViewModel.Preco, Descricao = produtoViewModel.Descricao, Foto = produtoViewModel.Foto };
            await _produtoRepository.Insert(produto);

            return result;
        }
    }
}

