using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Usuario.Interfaces
{
    public  interface IUsuarioExcluirUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(int id);
    }
}
