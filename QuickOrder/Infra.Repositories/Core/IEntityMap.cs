using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Core
{
    public interface IEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : EntityBase
    {
    }
}
