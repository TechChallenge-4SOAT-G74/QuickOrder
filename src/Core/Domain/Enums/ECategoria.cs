using System.ComponentModel;

namespace QuickOrder.Core.Domain.Enums
{
    public enum ECategoria
    {
        [Description("Lanche")]
        Lanche = 1,
        [Description("Acompanhamento")]
        Acompanhamento = 2,
        [Description("Bebida")]
        Bebida = 3,
        [Description("Sobremesa")]
        Sobremesa = 4
    }
}
