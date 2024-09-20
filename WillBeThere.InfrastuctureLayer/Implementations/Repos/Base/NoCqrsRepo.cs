using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Repos.Commands;
using SharedDomainLayer.Responses;
using System.Linq.Expressions;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos
{
    public class NoCqrsRepo<TDbContext> : INoCqrsRepo, IRepositoryBase
        where TDbContext : DbContext
    {
        private readonly TDbContext? _dbContext;
        public NoCqrsRepo(TDbContext? dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => await FindAll<TEntity>().ToListAsync();
        public async Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new() => await FindByCondition<TEntity>(entity => entity.Id == id).FirstOrDefaultAsync();        

        public async Task<Response> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();
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
            response.Append($"{nameof(NoCqrsRepo<TDbContext>)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett!");
            response.Append($"{entity} frissítése nem sikerült!");
            return response;
        }


        public async Task<Response> DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();
            if (entity is null)
                response.Append("Az entitás nem létezik, így nem törölhető!");
            else if (entity is TEntity && !entity.HasId)
                response.Append("Az entitás azonosítása nem sikerült, így nem törölhető!");
            else
            {
                try
                {
                    TDbContext? dbContext = GetDbContext<TEntity>();
                    if (dbContext is null)
                        response.Append($"Az adatbázis nem elérhető!");
                    else
                    {
                        dbContext.ChangeTracker.Clear();
                        dbContext.Entry(entity).State = EntityState.Deleted;
                        await dbContext.SaveChangesAsync();
                        return response;
                    }

                }
                catch (Exception e)
                {
                    response.Append(e.Message);
                }
            }
            response.Append($"{nameof(NoCqrsRepo<TDbContext>)} osztály, {nameof(DeleteAsync)} metódusban hiba keletkezett");
            if (entity is not null)
                response.Append($"Az entitás id:{entity.Id}");
            response.Append($"Az entitás törlése nem sikerült!");
            return response;
        }

        public async Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            TEntity? entityToDelete = FindByCondition<TEntity>(e => e.Id == id).FirstOrDefault();
            return await DeleteAsync(entityToDelete);
        }
        public async Task<Response> InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();

            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
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
            response.Append($"{nameof(NoCqrsRepo<TDbContext>)} osztály, {nameof(InsertAsync)} metódusban hiba keletkezett");
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

        protected DbSet<TEntity>? GetDbSet<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
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

        protected TDbContext? GetDbContext<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (_dbContext is null)
                return null;
            else
                return _dbContext;
        }


    }
}
