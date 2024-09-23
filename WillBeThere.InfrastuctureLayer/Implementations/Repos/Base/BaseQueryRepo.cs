using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.Base
{
    public class BaseQueryRepo<TDbContext> : RepositoryBase<DbContext>, IBaseQueryRepo where TDbContext : DbContext
    {

        public BaseQueryRepo(DbContext? dbContext) : base(dbContext) { }

        public IQueryable<TEntity> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => FindAll<TEntity>();

        public TEntity? GetById<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new() =>  FindByCondition<TEntity>(entity => entity.Id == id).FirstOrDefault();

        public  bool IsExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
                return false;
            else
                return  dbSet.Any(entity => entity.Id == id);
        }
    }
}
