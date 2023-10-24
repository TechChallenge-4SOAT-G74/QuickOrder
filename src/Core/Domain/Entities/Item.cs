using QuickOrder.Core.Domain.Enums;

namespace QuickOrder.Core.Domain.Entities
{
    public class Item : EntityBase
    {

        public ETipoItem TipoItem { get; set; }
        public double Valor { get; set; }
        public int? QuantidadeItem { get; set; }
    }
}
