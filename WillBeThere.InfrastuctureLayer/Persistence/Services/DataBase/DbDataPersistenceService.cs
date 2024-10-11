using SharedApplicationLayer.Contracts.Persistence;
using SharedDomainLayer.Responses;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase
{
    public class DbDataPersistenceService : IDataPersistenceService
    {
        public DbDataPersistenceService()
        {
        }

        public Task<Response> SaveMany<TEntity>(List<TEntity> entities) where TEntity : class, new()
        {

        }
    }
}
