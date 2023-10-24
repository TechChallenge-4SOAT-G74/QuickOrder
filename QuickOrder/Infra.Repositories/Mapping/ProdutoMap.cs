using Domain.Entities;
using Infra.Data.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
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
