using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Usuario.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Usuario
{
    public class UsuarioExcluirUseCase : IUsuarioExcluirUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioExcluirUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ServiceResult> Execute(int id)
        {
            ServiceResult result = new();
            try
            {
                var UsuarioExiste = await _usuarioRepository.GetFirst(id);

                if (UsuarioExiste == null)
                {
                    result.AddError("Usuario não encontrado.");
                    return result;
                }
                await _usuarioRepository.Delete(id);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
