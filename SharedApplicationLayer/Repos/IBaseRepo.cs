using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;

namespace SharedApplicationLayer.Repos
{
    public interface IBaseRepo
    {
        public DbSet<TEntity>? GetDbSet<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
