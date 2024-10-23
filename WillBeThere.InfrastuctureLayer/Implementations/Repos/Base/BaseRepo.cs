using Microsoft.EntityFrameworkCore;
using SharedApplicationLayer.Repos;
using SharedDomainLayer.Entities;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.Base
{
    public class BaseRepo<TDbContext> : IBaseRepo where TDbContext : DbContext 
    {
        protected readonly TDbContext? _dbContext;

        public BaseRepo(TDbContext? dbContext)
        {
            _dbContext = dbContext;
        }
        protected TDbContext? GetDbContext<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (_dbContext is null)
                return null;
            else
                return _dbContext;
        }

        public DbSet<TEntity>? GetDbSet<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            try
            {
                if (_dbContext is null)
                    return null;
                return _dbContext.Set<TEntity>();
            }
            catch (Exception) { }
            return null;
        }

        public IQueryable<TEntity>? GetQuery<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            try
            {
                if (_dbContext is null)
                    return null;
                return _dbContext.Set<TEntity>();
            }
            catch (Exception) { }
            return null;
        }

        public IQueryable<TEntity> SelectAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            try
            {
                if (_dbContext is not null)
                    return _dbContext.Set<TEntity>();
            }
            catch (Exception) { }
            return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
        }


    }
}
