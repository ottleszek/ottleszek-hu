using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Repos.Queries;
using Shared.DomainLayer.Entities;

namespace Shared.InfrastuctureLayer.Repos.DataBase.Queries
{
    public class BaseQueryDbRepo<TDbContext> : BaseDbRepo<DbContext>, IQueryGenericMethodRepo where TDbContext : DbContext
    {

        public BaseQueryDbRepo(DbContext? dbContext) : base(dbContext) { }

        public async Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => await GetQuery<TEntity>().FindAll().ToListAsync();

        public async Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new() => await GetQuery<TEntity>().FindByCondition(entity => entity.Id == id).FirstOrDefaultAsync();

        public async Task<bool> IsExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
                return await Task.FromResult(false);
            else
                return await Task.FromResult(dbSet.Any(entity => entity.Id == id));
        }
    }
}
