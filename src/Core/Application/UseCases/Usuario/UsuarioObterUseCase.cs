using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Usuario.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Usuario
{
    public class UsuarioObterUseCase : IUsuarioObterUseCase
    {
            private readonly IUsuarioRepository _usuarioRepository;

            public UsuarioObterUseCase(IUsuarioRepository usuarioRepository)
            {
                _usuarioRepository = usuarioRepository;
            }

            public async Task<ServiceResult<List<UsuarioDto>>> Execute()
            {
                ServiceResult<List<UsuarioDto>> result = new();
                try
                {
                    var usuarios = await _usuarioRepository.GetAll();

                    var list = new List<UsuarioDto>();

                    foreach (var usuario in usuarios)
                    {
                        //list.Add(new UsuarioDto
                        //{
                        //    Categoria = ECategoriaExtensions.ToDescriptionString((ECategoria)usuario.CategoriaId),
                        //    Nome = usuario.Nome.Nome,
                        //    Descricao = usuario.Descricao,
                        //    Preco = usuario.Preco,
                        //    usuarioItens = usuario.usuarioItens == null ? null : usuarioItensDto(usuario.usuarioItens)
                        //});
                    }


                    result.Data = list;
                }
                catch (Exception ex) { result.AddError(ex.Message); }
                return result;
            }

            public async Task<ServiceResult<UsuarioDto>> Execute(int id)
            {
                ServiceResult<UsuarioDto> result = new();
                try
                {
                    var usuario = await _usuarioRepository.GetFirst(id);
                    //result.Data = new UsuarioDto
                    //{
                    //    Categoria = ECategoriaExtensions.ToDescriptionString((ECategoria)usuario.CategoriaId),
                    //    Nome = usuario.Nome.Nome,
                    //    Descricao = usuario.Descricao,
                    //    Preco = usuario.Preco,
                    //    usuarioItens = usuario.usuarioItens == null ? null : usuarioItensDto(usuario.usuarioItens)

                    //};
                }
                catch (Exception ex) { result.AddError(ex.Message); }
                return result;
            }
        }
    
}
