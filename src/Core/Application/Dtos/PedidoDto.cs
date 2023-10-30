using QuickOrder.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOrder.Core.Application.Dtos
{
    public class PedidoDto
    {
        public int NumeroPedido { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFinalizado { get; set; }
        public int NumeroCliente { get; set; }
        public List<ProdutoItemPedido> ProdutosItemsPedido { get; set; }
        public double ValorPedido { get; set; }
        public string? Observacao { get; set; }
        public bool PedidoPago { get; set; }
    }
}