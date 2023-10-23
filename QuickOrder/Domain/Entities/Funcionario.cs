namespace Domain.Entities
{
    public class Funcionario : IEntity
    {
        public Guid Id { get; private set; }
        private readonly Usuario _usuario;

        public Funcionario(Usuario usuario, int matricula)
        {
            Id = Guid.NewGuid();
            _usuario = usuario;
            Matricula = matricula;
        }

        public int Matricula { get; set; }
        public Usuario Usuario => _usuario;
    }
}
