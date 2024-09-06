using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WillBeThere.Domain.Entities.DbIds;
using WillBeThere.Infrastucture.DataBrokers.Queries;
using WillBeThere.Infrastucture.Implementations.Repos.BaseRepos;

namespace WillBeThere.Infrastucture.Implementations.Repos.BaseCqrsRepos.Queries
{
    public class BaseQueryRepo<TDbContext> : BaseRepo<TDbContext>, IBaseQueryBroker, IRepositoryBase
        where TDbContext : DbContext
    {
        private readonly TDbContext? _dbContext;

        public BaseQueryRepo(TDbContext? dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => await FindAll<TEntity>().ToListAsync();

        Task<TEntity?> IBaseQueryBroker.GetByIdAsync<TEntity>(Guid id) where TEntity : class
        {
            throw new NotImplementedException();
        }

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
