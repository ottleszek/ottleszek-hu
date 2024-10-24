using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Repos.Commands;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.InfrastuctureLayer.Repos.DataBase.Commands
{
    public class BaseCommandRepo<TDbContext> : BaseDbRepo<TDbContext>, ICommandGenericMethodRepo where TDbContext : DbContext
    {
        public BaseCommandRepo(TDbContext? dbContext) : base(dbContext) { }

        public Response Update<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();
            try
            {
                DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
                if (_dbContext is null || dbSet is null)
                {
                    response.Append($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(Update)} metódusban hiba keletkezett!");
                    response.Append($"Az adatbázis nem elérhető!");
                    return response;
                }
                else
                {
                    var existingEntity = dbSet.Find(entity.Id);
                    if (existingEntity != null)
                        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Append(e.Message);
            }
            response.Append($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(Update)} metódusban hiba keletkezett!");
            response.Append($"{entity} frissítése nem sikerült!");
            return response;
        }


        public Response Delete<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new()
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
                    if (_dbContext is null)
                        response.Append($"Az adatbázis nem elérhető!");
                    else
                    {
                        _dbContext.Entry(entity).State = EntityState.Deleted;
                        return response;
                    }

                }
                catch (Exception e)
                {
                    response.Append(e.Message);
                }
            }
            if (entity is not null)
                response.Append($"Az entitás id:{entity.Id}");
            response.Append($"Az entitás törlése nem sikerült!");
            if (response.HasError)
                response.InsertToBegining($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(Delete)} metódusban hiba keletkezett!");
            return response;
        }

        public Response Delete<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            TEntity? entityToDelete = GetQuery<TEntity>().FindByCondition(e => e.Id == id).FirstOrDefault();
            return Delete(entityToDelete);
        }
        public Response Insert<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();

            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();

            if (dbSet is null)
            {
                response.Append($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(Insert)} metódusban hiba keletkezett!");
                response.Append($"Az adatbázis nem elérhető!");
                return response;
            }
            else
            {
                try
                {
                    dbSet.Add(entity);
                    return response;
                }
                catch (Exception e)
                {
                    response.Append(e.Message);
                }
            }
            response.Append($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(Insert)} metódusban hiba keletkezett!");
            response.Append($"{entity} osztály hozzáadása az adatbázishoz nem sikerült!");
            return response;
        }
    }
}
