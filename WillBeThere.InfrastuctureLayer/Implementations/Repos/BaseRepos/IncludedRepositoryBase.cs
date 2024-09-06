using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Entities.DbIds;
using WillBeThere.InfrastuctureLayer.DataBrokers;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos
{
    public abstract class IncludedRepositoryBase<TDbContext> : RepositoryBase<TDbContext>, IIncludedDataBroker
        where TDbContext : DbContext
    {
        protected IncludedRepositoryBase(TDbContext? dbContext) : base(dbContext)
        {
        }

        public IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => GetAllIncluded<TEntity>();

        protected abstract IQueryable<TEntity>? GetAllIncluded<TEntity>() where TEntity : class, new();
    }
}
