using QuickOrder.Core.Domain.ValueObjects;

namespace QuickOrder.Core.Domain.Entities
{
    public class Role : EntityBase, IAggregateRoot
    {
        protected Role() { }
        public Role(string nome, bool status, List<Funcionalidade> funcionalidades)
        {
            Nome = new NomeVo(nome);
            Status = status;
            Funcionalidades = funcionalidades;
        }

        public virtual NomeVo Nome { get; set; }
        public virtual bool Status { get; set; }
        public virtual int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Funcionalidade> Funcionalidades { get; set; }
    }
}
