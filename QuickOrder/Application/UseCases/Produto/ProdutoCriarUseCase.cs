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

        public async Task Execute(ProdutoDto produtoViewModel)
        {
            var produto = new ProdutoEntity(new NomeVo(produtoViewModel.Nome), (int)ECategoria.Lanche, produtoViewModel.Preco, produtoViewModel.Descricao, produtoViewModel.Foto);
            await _produtoRepository.Add(produto);
        }
    }
}

