using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace SharedApplicationLayer.Contracts.Persistence
{
    public interface IDataPersistenceService<TDto, TAssembler>
    {
        public Task<Response> SaveMany<TEntity>(List<TEntity> entities) where TEntity : class, IDbEntity<TEntity>,new();
    }
}
