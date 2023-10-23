using System.ComponentModel;

namespace Domain.Enums
{
    public enum ETipoItem
    {
        [Description("Pão")]
        Pao = 1,
        [Description("Carne")]
        Carne = 2,
        [Description("Queijo")]
        Queijo = 3,
        [Description("Molho")]
        Molho = 4,
        [Description("Administrador")]
        Complemento = 5
    }
}
