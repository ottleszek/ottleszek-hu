using Shared.ApplicationLayer.Repos.Queries;
using Shared.DomainLayer.Entities;

namespace Shared.ApplicationLayer.Repos
{
    public interface IIncludedQueryRepo : IQueryGenericMethodRepo
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
