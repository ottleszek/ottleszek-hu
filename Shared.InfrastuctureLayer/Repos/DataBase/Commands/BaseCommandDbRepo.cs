using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Repos;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.InfrastuctureLayer.Repos.DataBase.Commands
{
    public class BaseCommandDbRepo<TDbContext> : BaseDbRepo<TDbContext>, IBaseCommandDbRepo where TDbContext : DbContext
    {
        public BaseCommandDbRepo(TDbContext? dbContext) : base(dbContext) { }

        public Task<Response> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();
            try
            {
                DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
                if (_dbContext is null || dbSet is null)
                {
                    response.AppendError($"{nameof(BaseCommandDbRepo<TDbContext>)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett!");
                    response.AppendError($"Az adatbázis nem elérhető!");
                    return Task.FromResult(response);
                }
                else
                {
                    var existingEntity = dbSet.Find(entity.Id);
                    if (existingEntity != null)
                        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                    return Task.FromResult(response);
                }
            }
            catch (Exception e)
            {
                response.AppendError(e.Message);
            }
            response.AppendError($"{nameof(BaseCommandDbRepo<TDbContext>)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett!");
            response.AppendError($"{entity} frissítése nem sikerült!");
            return Task.FromResult(response);
        }


        public Task<Response> DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();
            if (entity is null)
                response.AppendError("Az entitás nem létezik, így nem törölhető!");
            else if (entity is TEntity && !entity.HasId)
                response.AppendError("Az entitás azonosítása nem sikerült, így nem törölhető!");
            else
            {
                try
                {
                    if (_dbContext is null)
                        response.AppendError($"Az adatbázis nem elérhető!");
                    else
                    {
                        _dbContext.Entry(entity).State = EntityState.Deleted;
                        return Task.FromResult(response);
                    }

                }
                catch (Exception e)
                {
                    response.AppendError(e.Message);
                }
            }
            if (entity is not null)
                response.AppendError($"Az entitás id:{entity.Id}");
            response.AppendError($"Az entitás törlése nem sikerült!");
            if (response.HasError)
                response.InsertToBegining($"{nameof(BaseCommandDbRepo<TDbContext>)} osztály, {nameof(DeleteAsync)} metódusban hiba keletkezett!");
            return Task.FromResult(response);
        }

        public Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            TEntity? entityToDelete = GetQuery<TEntity>().FindByCondition(e => e.Id == id).FirstOrDefault();
            return DeleteAsync(entityToDelete);
        }
        public Task<Response> InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();

            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();

            if (dbSet is null)
            {
                response.AppendError($"{nameof(BaseCommandDbRepo<TDbContext>)} osztály, {nameof(InsertAsync)} metódusban hiba keletkezett!");
                response.AppendError($"Az adatbázis nem elérhető!");
                return Task.FromResult(response);
            }
            else
            {
                try
                {
                    dbSet.Add(entity);
                    return Task.FromResult(response);
                }
                catch (Exception e)
                {
                    response.AppendError(e.Message);
                }
            }
            response.AppendError($"{nameof(BaseCommandDbRepo<TDbContext>)} osztály, {nameof(InsertAsync)} metódusban hiba keletkezett!");
            response.AppendError($"{entity} osztály hozzáadása az adatbázishoz nem sikerült!");
            return Task.FromResult(response);
        }
    }
}
