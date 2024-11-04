using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.ApplicationLayer.Persistence
{
    public interface IManyDataPersistenceService
    {
        Task<Response> UpdateMany<TEntity>(List<TEntity> entities) where TEntity : class, IDbEntity<TEntity>, new();
    }

    public interface IManyDataPersistenceService<TEntity> where TEntity : class, IDbEntity<TEntity>, new()
    {
        Task<Response> UpdateMany(List<TEntity> entities);
    }
}
