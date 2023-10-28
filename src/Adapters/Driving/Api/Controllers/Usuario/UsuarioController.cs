using Microsoft.AspNetCore.Mvc;
using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Usuario.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickOrder.Adapters.Driving.Api.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : CustomController<UsuarioController>
    {
        private readonly IUsuarioObterUseCase _usuarioObterUseCase;
        private readonly IUsuarioCriarUseCase _usuarioCriarUseCase;
        private readonly IUsuarioAtualizarUseCase _usuarioatualizarUseCase;
        private readonly IUsuarioExcluirUseCase _usuarioExcluirUseCase;

        public UsuarioController(ILogger<UsuarioController> logger,
           IUsuarioObterUseCase usuarioObterUseCase,
           IUsuarioCriarUseCase usuarioCriarUseCase,
           IUsuarioAtualizarUseCase usuarioatualizarUseCase,
           IUsuarioExcluirUseCase usuarioExcluirUseCase) : base(logger)
        {
            _usuarioObterUseCase = usuarioObterUseCase;
            _usuarioCriarUseCase = usuarioCriarUseCase;
            _usuarioatualizarUseCase = usuarioatualizarUseCase;
            _usuarioExcluirUseCase = usuarioExcluirUseCase;
        }

        /// <summary>
        /// Obter lista de Usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Result(await _usuarioObterUseCase.Execute());
        }

        /// <summary>
        /// Obter Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Result(await _usuarioObterUseCase.Execute(id));
        }

        /// <summary>
        /// Criar Usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDto usuario)
        {
            return Result(await _usuarioCriarUseCase.Execute(usuario));
        }

        /// <summary>
        /// Atualizar Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UsuarioDto usuario, int id)
        {
            return Result(await _usuarioatualizarUseCase.Execute(usuario, id));
        }


        /// <summary>
        /// Excluir Usuario
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Result(await _usuarioExcluirUseCase.Execute(id));
        }
    }
}
