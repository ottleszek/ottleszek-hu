using Microsoft.EntityFrameworkCore;
using Shared.DomainLayer.Entities;

namespace Shared.ApplicationLayer.Repos
{
    public interface IBaseDbRepo
    {
        DbSet<TEntity>? GetDbSet<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        IQueryable<TEntity>? GetQuery<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        IQueryable<TEntity> SelectAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
