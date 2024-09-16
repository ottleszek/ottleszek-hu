using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries
{
    public abstract class IncludedQueryRepo<TDbContext> : BaseQueryRepo<TDbContext>, IIncludedQueryRepo
        where TDbContext : DbContext
    {
        protected IncludedQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        public IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => GetAllIncluded<TEntity>();

        protected abstract IQueryable<TEntity>? GetAllIncluded<TEntity>() where TEntity : class, new();
    }
}
