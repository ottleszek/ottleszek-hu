using SharedApplicationLayer.Contracts.Persistence;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase
{
    public class DbDataPersistenceService : IDataPersistenceService
    {
        private IUnitOfWork _unitOfWork;
        private I
        public DbDataPersistenceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<Response> SaveMany<TEntity>(List<TEntity> entities) where TEntity : class, new()
        {
            _unitOfWork.SetRepository()

        }
    }
}
