using Microsoft.EntityFrameworkCore;
using SharedApplicationLayer.Contracts.Persistence;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.Base
{ 
    public class BaseManyCommandRepo<TDbContext> : IDataPersistenceService where TDbContext : DbContext
    {
        protected readonly TDbContext? _dbContext;
        public BaseManyCommandRepo(TDbContext? dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Response> SaveMany<TEntity>(List<TEntity> entities) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();

            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
            {
                response.Append($"{nameof(BaseManyCommandRepo<TDbContext>)} osztály, {nameof(SaveMany)} metódusban hiba keletkezett!");
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
            response.Append($"{nameof(BaseManyCommandRepo<TDbContext>)} osztály, {nameof(SaveMany)} metódusban hiba keletkezett!");
            response.Append($"{nameof(TEntity)} típusú és {entities.Count} db elem mentése az adatbázisba nem sikerült!");
            return Task.FromResult(response);
        }

        protected DbSet<TEntity>? GetDbSet<TEntity>() where TEntity : class
        {
            try
            {
                if (_dbContext is null)
                    return null;
                return _dbContext.Set<TEntity>();
            }
            catch (Exception) { }
            return null;
        }
    }
}
