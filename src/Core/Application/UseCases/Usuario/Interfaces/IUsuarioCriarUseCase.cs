using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Usuario.Interfaces
{
    public interface IUsuarioCriarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(UsuarioDto produto);
    }
}
