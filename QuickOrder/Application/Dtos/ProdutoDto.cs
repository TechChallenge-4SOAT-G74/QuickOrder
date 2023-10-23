using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Categoria { get; set; }
       // public ICollection<ProdutoItem>? ProdutoItems { get; set; }
        public double Preco { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }

    }
}
