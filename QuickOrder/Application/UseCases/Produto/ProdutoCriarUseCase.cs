using Application.Dtos;
using Application.UseCases.Produto.Interfaces;
using Domain.Enums;
using Domain.Repositories;
using Domain.ValueObjects;
using ProdutoEntity = Domain.Entities.Produto;

namespace Application.UseCases.Produto
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
            var produto = new ProdutoEntity { Nome = produtoViewModel.Nome, CategoriaId = (int)ECategoria.Lanche, Preco = produtoViewModel.Preco, Descricao =  produtoViewModel.Descricao, Foto = produtoViewModel.Foto };
            await _produtoRepository.Insert(produto);

            return result;
        }
    }
}

