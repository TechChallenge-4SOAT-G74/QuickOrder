using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickOrder.Adapters.Driven.PostgresDB.Migrations
{
    public partial class insertinicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (1, 'Big Mag', 1, 20, 'Dois hambúrgueres (100% carne bovina), alface americana, queijo sabor cheddar, molho especial, cebola, picles e pão com gergelim.');
	            INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (2, 'McFritas Grande', 2, 9, 'A batata frita mais famosa do mundo. Deliciosas batatas selecionadas, fritas, crocantes por fora, macias por dentro, douradas, irresistíveis, saborosas, famosas, e todos os outros adjetivos positivos que você quiser dar.');
	            INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (3, 'Coca-Cola 500ml', 3, 7, 'Refrescante e geladinha. Uma bebida assim refresca a vida. Você pode escolher entre Coca-Cola, Coca-Cola Zero, Sprite sem Açúcar, Fanta Guaraná e Fanta Laranja.');
	            INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (4, 'Sundae morango', 4, 9, 'A medida certa entre cobertura de morango e bebida láctea sabor baunilha que pode fazer você viver uma experiência explosiva, além de amendoins crocantes. Desfrute dessa combinação perfeita!');
	            INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (5, 'Chicken McNuggets 10 unidades', 1, 12, 'Crocantes, leves e deliciosos. Os frangos empanados mais irresistíveis do McDonald’s.');
	            INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (6, 'Torta de maçã', 4, 7, 'Boa demais. Parece a receita lá de casa. Massa quentinha e crocante envolvendo deliciosos recheios de banana ou maçã com gostinho de doce caseiro.');
                INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (7, 'Casquinha baunilha', 4, 6, 'A sobremesa que o Brasil todo adora. Uma casquinha supercrocante, com bebida láctea sabor baunilha que vai bem a qualquer hora.');
                INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (8, 'Quarterão com Queijo', 1, 19, 'Um hambúrguer (100% carne bovina), queijo sabor cheddar, picles, cebola, ketchup, mostarda e pão com gergelim.');
                INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (9, 'McShake Ovomaltine', 4, 12, 'Deliciosamente cremoso. O novo McShake Ovomaltine é feito com leite e batido na hora. Uma delícia!');
                INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (10, 'Pão de Queijo', 1, 6, 'Impossível de resistir. Pão de queijo quentinho e macio. Quem já provou sabe que não tem igual.');
                INSERT INTO ""Produto"" (""Id"", ""Nome"", ""CategoriaId"", ""Preco"", ""Descricao"") VALUES (11, 'Iced Mix Café', 3, 8, 'O sabor é tão refrescante quanto delicioso. Feito com o saboroso espresso do McCafé em uma combinação com a nossa bebida láctea sabor baunilha batido com pedras de gelo, finalizado chocolate em pó polvilhado.');

                INSERT INTO ""Usuario"" (""Id"", ""Nome"", ""Cpf"", ""Email"", ""Status"") VALUES (1, 'Ronald McDonald', '11111111111', 'ronald@mcdonalds.com', true);

                INSERT INTO ""Cliente"" (""Id"", ""DDD"", ""Telefone"", ""DataNascimento"", ""Usuario"") VALUES (1, '21', '99999-9999', '01/01/1963', 1);"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
