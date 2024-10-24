using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Contracts.Persistence;
using Shared.ApplicationLayer.Repos.Commands;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase
{
    public class DbDataPersistenceService : IDataPersistenceService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly ICommandGenericMethodRepo? _baseCommandRepo;

        public DbDataPersistenceService(IUnitOfWork? unitOfWork, ICommandGenericMethodRepo? baseRepo)
        {
            _unitOfWork = unitOfWork;
            _baseCommandRepo = baseRepo;
        }

        public async Task<Response> UpdateMany<TEntity>(List<TEntity> entities) where TEntity : class,IDbEntity<TEntity>,  new()
        {
            Response response = new();
            DbSet<TEntity>? dbSet;

            if (_baseCommandRepo is null || _unitOfWork is null)
            {
                response.Append($"{nameof(DbDataPersistenceService)} osztály, {nameof(UpdateMany)} metódusban hiba keletkezett!");
                response.Append($"Az adatbázis nem elérhető!");
                return response;
            }
            else
            {

                dbSet = _baseCommandRepo.GetDbSet<TEntity>();
                if (dbSet is null)
                {
                    response.Append($"{nameof(DbDataPersistenceService)} osztály, {nameof(UpdateMany)} metódusban hiba keletkezett!");
                    response.Append($"Az adatbázis nem elérhető!");
                    return response;
                }
                else
                {
                    try
                    {

                        await _unitOfWork.BeginTransactionAsync();
                        {
                            try
                            {
                                foreach (var entity in entities)
                                {
                                    _baseCommandRepo.Update(entity);
                                }
                                await _unitOfWork.SaveChangesAsync();
                                _unitOfWork.Commit();
                            }
                            catch (Exception ex) 
                            {
                                _unitOfWork.Rollback();
                                return new Response { Error = ex.Message };

                                
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        response.Append(e.Message);
                    }
                }
            }
            response.Append($"{nameof(DbDataPersistenceService)} osztály, {nameof(UpdateMany)} metódusban hiba keletkezett!");
            response.Append($"{entities.Count} db {nameof(TEntity)} objektum hozzáadása az adatbázishoz nem sikerült!");
            return response;
        }
    }
}
