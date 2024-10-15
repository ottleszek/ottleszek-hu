using Microsoft.EntityFrameworkCore;
using SharedApplicationLayer.Contracts.Persistence;
using SharedApplicationLayer.Repos;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase
{
    public class DbDataPersistenceService : IDataPersistenceService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IBaseRepo? _baseRepo;

        public DbDataPersistenceService(IUnitOfWork? unitOfWork, IBaseRepo? baseRepo)
        {
            _unitOfWork = unitOfWork;
            _baseRepo = baseRepo;
        }

        public Task<Response> SaveMany<TEntity>(List<TEntity> entities) where TEntity : class,IDbEntity<TEntity>,  new()
        {
            Response response = new();
            DbSet<TEntity>? dbSet;

            if (_baseRepo is null)
            {
                response.Append($"{nameof(DbDataPersistenceService)} osztály, {nameof(SaveMany)} metódusban hiba keletkezett!");
                response.Append($"Az adatbázis nem elérhető!");
                return Task.FromResult(response);
            }
            else
            {

                dbSet = _baseRepo.GetDbSet<TEntity>();
                if (dbSet is null)
                {
                    response.Append($"{nameof(DbDataPersistenceService)} osztály, {nameof(SaveMany)} metódusban hiba keletkezett!");
                    response.Append($"Az adatbázis nem elérhető!");
                    return Task.FromResult(response);
                }
                else
                {
                    try
                    {
                        dbSet.AddRange(entities);
                        return Task.FromResult(response);
                    }
                    catch (Exception e)
                    {
                        response.Append(e.Message);
                    }
                }
            }
            response.Append($"{nameof(DbDataPersistenceService)} osztály, {nameof(SaveMany)} metódusban hiba keletkezett!");
            response.Append($"{entities.Count} db {nameof(TEntity)} objektum hozzáadása az adatbázishoz nem sikerült!");
            return Task.FromResult(response);
        }
    }
}
