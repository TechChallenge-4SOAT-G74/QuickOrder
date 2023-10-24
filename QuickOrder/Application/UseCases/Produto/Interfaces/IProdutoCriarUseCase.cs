using Application.Dtos;

namespace Application.UseCases.Produto.Interfaces
{
    public interface IProdutoCriarUseCase
    {
        Task<ServiceResult> Execute(ProdutoDto produto);
    }
}
