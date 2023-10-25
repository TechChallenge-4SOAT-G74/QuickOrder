using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class RoleMap : IEntityMap<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.OwnsOne(x => x.Nome, nome =>
            {
                nome.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(150)")
                .IsRequired(true);
            });

            builder.Property(x => x.Status)
                  .IsRequired();
            builder.HasMany(x => x.Funcionalidades);
        }
    }
}

