using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Usuario.Interfaces
{
    public interface IUsuarioAtualizarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(UsuarioDto produto, int id);
    }
}
