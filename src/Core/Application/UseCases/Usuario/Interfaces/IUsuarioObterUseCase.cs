using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Usuario.Interfaces
{
    public interface IUsuarioObterUseCase : IBaseUseCase
    {
        Task<ServiceResult<List<UsuarioDto>>> Execute();
        Task<ServiceResult<UsuarioDto>> Execute(int id);
    }
}
