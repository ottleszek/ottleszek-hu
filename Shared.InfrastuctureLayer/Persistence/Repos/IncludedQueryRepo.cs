using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Repos;
using Shared.DomainLayer.Entities;
using Shared.InfrastuctureLayer.Persistence.Repos.Queries;

namespace Shared.InfrastuctureLayer.Persistence.Repos
{
    public abstract class IncludedQueryRepo<TDbContext> : BaseQueryDbRepo<TDbContext>, IIncludedQueryRepo where TDbContext : DbContext
    {
        protected IncludedQueryRepo(TDbContext? dbContext) : base(dbContext) { }


        public IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => GetAllIncluded<TEntity>();

        protected abstract IQueryable<TEntity>? GetAllIncluded<TEntity>() where TEntity : class, new();
    }
}
