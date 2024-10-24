using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.ApplicationLayer.Contracts.Persistence
{
    public interface IDataPersistenceService
    {
        Task<Response> UpdateMany<TEntity>(List<TEntity> entities) where TEntity : class, IDbEntity<TEntity>,new();
    }

    public interface IDataPersistenceService<TEntity>
        where TEntity : class, IDbEntity<TEntity>, new()
    {
        Task<Response> UpdateMany(List<TEntity> entities);
    }
}
