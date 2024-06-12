using Microsoft.EntityFrameworkCore;
using WillBeThere.Shared.DataBroker;
using WillBeThere.Shared.Models;

namespace WillBeThere.Backend.Repos
{
    public abstract class IncludedRepositoryBase<TDbContext> : IIncludedDataBroker
        where TDbContext : DbContext
    {
        public IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => GetAllIncluded<TEntity>();

        protected abstract IQueryable<TEntity>? GetAllIncluded<TEntity>() where TEntity : class, new();
    }
}
