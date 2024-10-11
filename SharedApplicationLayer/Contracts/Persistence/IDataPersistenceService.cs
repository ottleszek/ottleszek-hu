using SharedDomainLayer.Responses;

namespace SharedApplicationLayer.Contracts.Persistence
{
    public interface IDataPersistenceService
    {
        public Task<Response> SaveMany<TEntity>(List<TEntity> entities) where TEntity : class,new();
    }
}
