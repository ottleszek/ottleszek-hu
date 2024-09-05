using Microsoft.EntityFrameworkCore;
using WillBeThere.Domain.Entities.DbIds;

namespace WillBeThere.Infrastucture.Implementations.Repos.BaseRepos
{
    public class BaseRepo<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext? _dbContext;

        public BaseRepo(TDbContext? dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbSet<TEntity>? GetDbSet<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
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

        protected TDbContext? GetDbContext<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (_dbContext is null)
                return null;
            else
                return _dbContext;
        }

    }
}
