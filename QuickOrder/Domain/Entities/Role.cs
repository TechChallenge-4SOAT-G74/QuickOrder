using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Role : EntityBase
    {
        public bool Status { get; set; }
        public List<Funcionalidade> Funcionalidades { get; set; }
    }
}
