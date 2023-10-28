using QuickOrder.Core.Domain.ValueObjects;

namespace QuickOrder.Core.Domain.Entities
{
    public class Produto : EntityBase, IAggregateRoot
    {
        protected Produto() { }
        public Produto(string nome, int categoriaId, double preco, string? descricao = null, string? foto = null, List<ProdutoItem>? produtoItens = null)
        {
            Nome = new NomeVo(nome);
            CategoriaId = categoriaId;
            Preco = preco;
            Descricao = descricao;
            Foto = foto;
            ProdutoItens = produtoItens;


            //ValidaProduto();
            // ValidaPreco();
        }

        public virtual NomeVo Nome { get; set; }
        public virtual int CategoriaId { get; set; }
        public virtual double Preco { get; set; }
        public virtual string? Descricao { get; set; }
        public virtual string? Foto { get; set; }


        public virtual List<ProdutoItem>? ProdutoItens { get; set; }

        public bool Any()
        {
            throw new NotImplementedException();
        }

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
