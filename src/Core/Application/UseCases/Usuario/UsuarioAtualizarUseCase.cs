using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Usuario.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Usuario
{
    public class UsuarioAtualizarUseCase : IUsuarioAtualizarUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAtualizarUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ServiceResult> Execute(UsuarioDto usuarioViewModel, int id)
        {
            ServiceResult result = new();
            try
            {
                var usuarioExiste = await _usuarioRepository.GetFirst(id);

                if (usuarioExiste == null)
                {
                    result.AddError("usuario não encontrado.");
                    return result;
                }

                //usuarioExiste.Nome = new NomeVo(usuarioViewModel.Nome);
                //usuarioExiste.CategoriaId = (int)(ECategoria)Enum.Parse(typeof(ECategoria), usuarioViewModel.Categoria);
                //usuarioExiste.Preco = usuarioViewModel.Preco;
                //usuarioExiste.Descricao = usuarioViewModel.Descricao ?? null;
                //usuarioExiste.Foto = usuarioViewModel.Foto ?? null;

                await _usuarioRepository.Update(usuarioExiste);

            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
