using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Responses;
using WillBeThere.DomainLayer.Entities.DbIds;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands
{
    public class BaseCommandRepo<TDbContext> : RepositoryBase<DbContext>, IBaseCommandRepo where TDbContext : DbContext
    {    
        public BaseCommandRepo(DbContext? dbContext) : base(dbContext) { }

        public Response UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();
            try
            {
                if (_dbContext is null)
                {
                    response.Append($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett!");
                    response.Append($"Az adatbázis nem elérhető!");
                    return response;
                }
                else
                {
                    _dbContext.ChangeTracker.Clear();
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    return response;
                }
            }
            catch (Exception e)
            {
                response.Append(e.Message);
            }
            response.Append($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett!");
            response.Append($"{entity} frissítése nem sikerült!");
            return response;
        }


        public Response DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new()
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
                response.InsertToBegining($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(DeleteAsync)} metódusban hiba keletkezett");
            return response;
        }

        public Response DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            TEntity? entityToDelete = FindByCondition<TEntity>(e => e.Id == id).FirstOrDefault();
            return DeleteAsync<TEntity>(entityToDelete);
        }
        public Response InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();

            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();

            if (dbSet is null)
            {
                response.Append($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(InsertAsync)} metódusban hiba keletkezett");
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

                response.Append($"{nameof(BaseCommandRepo<TDbContext>)} osztály, {nameof(InsertAsync)} metódusban hiba keletkezett");
                response.Append($"{entity} osztály hozzáadása az adatbázishoz nem sikerült!");
            }
            return response;
        }            
    }
}
