using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Usuario.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using UsuarioEntity = QuickOrder.Core.Domain.Entities.Usuario;

namespace QuickOrder.Core.Application.UseCases.Usuario
{
    public  class UsuarioCriarUseCase: IUsuarioCriarUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCriarUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ServiceResult> Execute(UsuarioDto usuarioViewModel)
        {
            ServiceResult result = new();
            try
            {
                var usuarioExiste = await _usuarioRepository.GetFirst(x => x.Nome.Nome.Equals(usuarioViewModel.Nome));
                if (usuarioExiste != null)
                {
                    result.AddError("usuario já existe.");
                    return result;
                }

                //var usuario = new UsuarioEntity();
                ////    usuarioViewModel.Nome,
                ////    (int)(ECategoria)Enum.Parse(typeof(ECategoria), usuarioViewModel.Categoria),
                ////    usuarioViewModel.Preco,
                ////    usuarioViewModel.Descricao,
                ////    usuarioViewModel.Foto
                ////    );

                //var usuarioInsert = await _usuarioRepository.Insert(usuario);

            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
