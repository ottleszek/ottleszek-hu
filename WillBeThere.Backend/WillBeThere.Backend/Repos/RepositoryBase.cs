using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WillBeThere.Shared.Models.DbIds;
using WillBeThere.Shared.Responses;

namespace WillBeThere.Backend.Repos
{
    public class RepositoryBase<TDbContext> : IDataBroker
        where TDbContext : DbContext
    {
        private readonly TDbContext? _dbContext;
        public RepositoryBase(TDbContext? dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> SelectAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => await FindAll<TEntity>().ToListAsync();

        public async Task<List<TEntity>> SelectAll<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IDbEntity<TEntity>, new() => await FindByCondition<TEntity>(expression).ToListAsync();

        public async Task<Response> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new ()
        {
            Response response = new Response();
            try
            {
                TDbContext? dbContext = GetDbContext<TEntity>();
                if (dbContext is null)
                    response.Append($"Az adatbázis nem elérhető!");
                else
                {
                    dbContext.ChangeTracker.Clear();
                    dbContext.Entry(entity).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Append(e.Message);
            }
            response.Append($"{nameof(RepositoryBase<TDbContext>)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett!");
            response.Append($"{entity} frissítése nem sikerült!");
            return response;
        }
        public async Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new Response();

            TEntity? entityToDelete = FindByCondition<TEntity>(e => e.Id == id).FirstOrDefault();

            if (entityToDelete is null || (entityToDelete is not null && !entityToDelete.HasId))
            {
                if (entityToDelete is not null)
                    response.Append($"{entityToDelete.Id} idével rendelkező entitás nem található!");
                response.Append("Az entitás törlése nem sikerült!");
            }
            else
            {
                try
                {
                    if (entityToDelete is not null)
                    {
                        TDbContext? dbContext = GetDbContext<TEntity>();
                        if (dbContext is null)
                            response.Append($"Az adatbázis nem elérhető!");
                        else
                        {
                            dbContext.ChangeTracker.Clear();
                            dbContext.Entry(entityToDelete).State = EntityState.Deleted;
                            await dbContext.SaveChangesAsync();
                            return response;
                        }
                    }
                }
                catch (Exception e)
                {
                    response.Append(e.Message);
                }
            }
            response.Append($"{nameof(RepositoryBase<TDbContext>)} osztály, {nameof(DeleteAsync)} metódusban hiba keletkezett");
            if (entityToDelete is not null)
                response.Append($"Az entitás id:{entityToDelete.Id}");
            response.Append($"Az entitás törlése nem sikerült!");
            return response;
        }
        public async Task<Response> CreateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new Response();

            DbSet<TEntity>? dbSet= GetDbSet<TEntity>();
            TDbContext? dbContext = GetDbContext<TEntity>();

            if (dbContext is null || dbSet is null)
                response.Append($"Az adatbázis nem elérhető!");
            else
            {
                try
                {
                    dbSet.Add(entity);
                    await dbContext.SaveChangesAsync();
                    return response;
                }
                catch (Exception e)
                {
                    response.Append(e.Message);
                }
            }
            response.Append($"{nameof(RepositoryBase<TDbContext>)} osztály, {nameof(CreateAsync)} metódusban hiba keletkezett");
            response.Append($"{entity} osztály hozzáadása az adatbázishoz nem sikerült!");
            return response;
        }

        public IQueryable<TEntity> FindAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            return dbSet.AsNoTracking();
        }
        public IQueryable<TEntity> FindByCondition<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IDbEntity<TEntity>, new()
        {
            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            return dbSet.Where(expression).AsNoTracking();
        }

        private DbSet<TEntity>? GetDbSet<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            try
            {
                if (_dbContext is null)
                    return null;
                return _dbContext.Set<TEntity>();
            }
            catch (Exception ) { }
            return null;
        }

        private TDbContext? GetDbContext<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {

            if (_dbContext is null)
                return null;
            else
                return _dbContext;
        }
    }
}
