using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Persistence;
using Shared.ApplicationLayer.Repos;
using Shared.ApplicationLayer.Repos.UnitOfWork;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase
{
    public class ManyDataDbPersistenceService : IManyDataPersistenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseCommandDbRepo _baseCommandRepo;

        public ManyDataDbPersistenceService(IUnitOfWork unitOfWork, IBaseCommandDbRepo baseRepo)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _baseCommandRepo = baseRepo ?? throw new ArgumentNullException(nameof(baseRepo));
        }

        public async Task<Response> UpdateMany<TEntity>(List<TEntity> entities) where TEntity : class,IDbEntity<TEntity>,  new()
        {
            Response response = new();
            DbSet<TEntity>? dbSet = _baseCommandRepo.GetDbSet<TEntity>();

            if (dbSet is null)
            {
                return response.AppendError($"{nameof(ManyDataDbPersistenceService)} osztály, {nameof(UpdateMany)} metódusban hiba keletkezett! Az adatbázis nem elérhető!");
            }
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                {

                    dbSet.UpdateRange(entities);
                    await _unitOfWork.SaveChangesAsync();
                    _unitOfWork.Commit();
                }
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                return response.AppendError(e.Message);
            }                      
            return response;
        }
    }
}
