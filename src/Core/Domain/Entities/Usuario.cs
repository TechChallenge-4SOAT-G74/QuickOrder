using QuickOrder.Core.Domain.ValueObjects;

namespace QuickOrder.Core.Domain.Entities
{
    public class Usuario : EntityBase, IAggregateRoot
    {
        protected Usuario() { }

        public Usuario(string nome, string cpf, string email, bool status, List<Role> roles)
        {
            Nome = new NomeVo(nome);
            Cpf = new CpfVo(cpf);
            Email = new EmailVo(email);
            Status = status;
            Roles = roles;
        }

        public virtual NomeVo Nome { get; private set; }
        public virtual CpfVo Cpf { get; private set; }
        public virtual EmailVo Email { get; private set; }
        public virtual bool Status { get; private set; }
        public virtual List<Role> Roles { get; set; }
        public virtual List<Cliente> Clientes { get; set; }
        public virtual List<Funcionario> Funcionarios { get; set; }

    }
}
