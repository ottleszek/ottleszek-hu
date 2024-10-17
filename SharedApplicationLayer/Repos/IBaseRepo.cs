using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;

namespace SharedApplicationLayer.Repos
{
    public interface IBaseRepo
    {
        DbSet<TEntity>? GetDbSet<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        IQueryable<TEntity>? GetQuery<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        IQueryable<TEntity> Select<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
