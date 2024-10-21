using SharedApplicationLayer.Transformers;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace SharedApplicationLayer.Contracts.Persistence
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
