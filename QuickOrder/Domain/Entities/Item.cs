using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Item : EntityBase
    {

        public ETipoItem TipoItem { get; set; }
        public double Valor { get; set; }
        public int? QuantidadeItem { get; set; }
    }
}
