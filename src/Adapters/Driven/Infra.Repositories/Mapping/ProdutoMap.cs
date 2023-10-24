using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class ProdutoMap : IEntityMap<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.CategoriaId)
                   .IsRequired();
            builder.Property(x => x.Preco)
                  .IsRequired();
            builder.Property(x => x.Descricao)
                  .IsRequired(false);
            builder.Property(x => x.Foto)
                  .IsRequired(false);
            builder.Property(x => x.Nome)
                .IsRequired(true);

        }
    }
}
