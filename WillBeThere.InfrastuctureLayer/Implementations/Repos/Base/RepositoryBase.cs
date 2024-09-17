using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Repos.Commands;
using System.Linq.Expressions;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos
{
    public class RepositoryBase<TDbContext> : BaseRepo<TDbContext>, IRepositoryBase where TDbContext : DbContext
    {
        public RepositoryBase(TDbContext? dbContext) : base(dbContext) { }        

        public IQueryable<TEntity> FindAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            return dbSet.AsNoTracking();
        }
        public IQueryable<TEntity> FindByCondition<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IDbEntity<TEntity>, new()
        {
            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            return dbSet.Where(expression).AsNoTracking();
        }
    }
}
