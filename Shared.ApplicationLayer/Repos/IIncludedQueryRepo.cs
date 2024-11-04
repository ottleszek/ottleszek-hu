using Shared.DomainLayer.Entities;

namespace Shared.ApplicationLayer.Repos
{
    public interface IIncludedQueryRepo : IBaseQueryDbRepo
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
