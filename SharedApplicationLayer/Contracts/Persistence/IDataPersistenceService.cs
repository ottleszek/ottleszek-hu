using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace SharedApplicationLayer.Contracts.Persistence
{
    public interface IDataPersistenceService
    {
        Task<Response> SaveMany<TEntity>(List<TEntity> entities) where TEntity : class, IDbEntity<TEntity>,new();
    }

    public interface IDataPersistenceService<TEntity>
    {
        Task<Response> SaveMany(List<TEntity> entities);
    }
}
