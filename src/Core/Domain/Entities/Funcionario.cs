namespace QuickOrder.Core.Domain.Entities
{
    public class Funcionario : EntityBase
    {
        private readonly Usuario _usuario;

        public int Matricula { get; set; }
        public Usuario Usuario => _usuario;
    }
}
