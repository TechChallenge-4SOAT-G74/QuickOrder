using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class FuncionalidadeMap : IEntityMap<Funcionalidade>
    {
        public void Configure(EntityTypeBuilder<Funcionalidade> builder)
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
            builder.Property(x => x.RoleId)
                .HasColumnName("Role")
                .IsRequired();
            builder.HasOne(x => x.Role)
                   .WithMany(x => x.Funcionalidades);

        }
    }
}

