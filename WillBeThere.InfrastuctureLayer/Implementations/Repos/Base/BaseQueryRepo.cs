using Microsoft.EntityFrameworkCore;
using SharedApplicationLayer.Repos;
using SharedDomainLayer.Entities;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.Base
{
    public class BaseQueryRepo<TDbContext> : BaseRepo<DbContext> , IBaseQueryRepo where TDbContext : DbContext
    {

        public BaseQueryRepo(DbContext? dbContext) : base(dbContext) { }

        public async Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => await GetQuery<TEntity>().FindAll().ToListAsync();

        public async Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new() => await GetQuery<TEntity>().FindByCondition<        TEntity>(entity => entity.Id == id).FirstOrDefaultAsync();

        public async Task<bool> IsExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
                return await Task.FromResult(false);
            else
                return  await Task.FromResult(dbSet.Any(entity => entity.Id == id));
        }
    }
}
