namespace QuickOrder.Core.Application.Dtos
{
    public class UsuarioDto
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public bool Status { get; private set; }
    }
}
