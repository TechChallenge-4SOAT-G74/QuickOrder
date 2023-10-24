namespace QuickOrder.Core.Domain.Entities
{
    public class Produto : EntityBase, IAggregateRoot
    {

        public string? Nome { get; set; }
        public int CategoriaId { get; set; }
        public double Preco { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }


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
