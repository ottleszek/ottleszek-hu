using SharedApplicationLayer.Transformers;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace SharedApplicationLayer.Contracts.Persistence
{
    public interface IDataPersistenceService
    {
        Task<Response> SaveMany<TEntity>(List<TEntity> entities) where TEntity : class, IDbEntity<TEntity>,new();
    }

    public interface IDataPersistenceService<TEntity>
        where TEntity : class, IDbEntity<TEntity>, new()
    {
        Task<Response> SaveMany(List<TEntity> entities);
    }
}
