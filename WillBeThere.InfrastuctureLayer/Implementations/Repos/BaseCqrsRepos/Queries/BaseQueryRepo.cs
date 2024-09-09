using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WillBeThere.DomainLayer.Entities.DbIds;
using WillBeThere.InfrastuctureLayer.DataBrokers.Queries;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries
{
    public class BaseQueryRepo<TDbContext> : BaseRepo<DbContext>, IBaseQueryBroker, IRepositoryBase where TDbContext : DbContext
    {
        protected readonly DbContext? _dbContext;

        public BaseQueryRepo(DbContext? dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => await FindAll<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new () => await FindByCondition<TEntity>(entity => entity.Id == id).FirstOrDefaultAsync();

        public async Task<bool> ExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
                return false;
            else
                return await dbSet.AnyAsync(entity => entity.Id == id);
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
    }
}
