using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Produto : EntityBase, IAggregateRoot
    {
       
        public Produto(NomeVo nome, int categoriaId, double preco, string? descricao = null, string? foto = null, List<ProdutoItem>? produtoItems = null): base(nome)
        {

            Nome = nome;
            CategoriaId = categoriaId;
            Preco = preco;
            Descricao = descricao;
            Foto = foto;
            ProdutoItems = produtoItems;
        }

         protected Produto(NomeVo nome) : base(nome) { }

        public int CategoriaId { get; set; }
        public double Preco { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }
        public List<ProdutoItem>? ProdutoItems { get; set; }


        //public void ValidaProduto()
        //{
        //    //TODO: Validar estrutura Produto
        //}

        //public void ValidaPreco()
        //{
        //    //TODO: Validar se o preço default do Produto que possui items não pode ser inferior à soma do valor destes items
        //}
    }
}
