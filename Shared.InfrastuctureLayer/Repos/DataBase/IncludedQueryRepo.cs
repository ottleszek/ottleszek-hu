using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Repos;
using Shared.DomainLayer.Entities;
using Shared.InfrastuctureLayer.Repos.DataBase.Queries;

namespace Shared.InfrastuctureLayer.Repos.DataBase
{
    public abstract class IncludedQueryRepo<TDbContext> : BaseQueryRepo<TDbContext>, IIncludedQueryRepo where TDbContext : DbContext
    {
        protected IncludedQueryRepo(DbContext? dbContext) : base(dbContext) { }


        public IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => GetAllIncluded<TEntity>();

        protected abstract IQueryable<TEntity>? GetAllIncluded<TEntity>() where TEntity : class, new();
    }
}
