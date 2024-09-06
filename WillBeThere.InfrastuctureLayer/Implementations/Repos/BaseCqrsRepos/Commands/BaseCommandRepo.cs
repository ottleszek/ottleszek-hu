using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Responses;
using WillBeThere.DomainLayer.Entities.DbIds;
using WillBeThere.InfrastuctureLayer.DataBrokers.Commands;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands
{
    public class BaseCommandRepo<TDbContext> : BaseQueryRepo<TDbContext>, IBaseCommandBroker
                where TDbContext : DbContext
    {
        private readonly TDbContext? _dbContext;

        public BaseCommandRepo(TDbContext? dbContext)
            :base(dbContext)
        {
            _dbContext = dbContext;
        }
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
            response.Append($"{nameof(RepositoryBase<TDbContext>)} osztály, {nameof(UpdateAsync)} metódusban hiba keletkezett!");
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
            response.Append($"{nameof(RepositoryBase<TDbContext>)} osztály, {nameof(DeleteAsync)} metódusban hiba keletkezett");
            if (entity is not null)
                response.Append($"Az entitás id:{entity.Id}");
            response.Append($"Az entitás törlése nem sikerült!");
            return response;
        }

        public async Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            TEntity? entityToDelete = FindByCondition<TEntity>(e => e.Id == id).FirstOrDefault();
            return await DeleteAsync<TEntity>(entityToDelete);
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
            response.Append($"{nameof(RepositoryBase<TDbContext>)} osztály, {nameof(InsertAsync)} metódusban hiba keletkezett");
            response.Append($"{entity} osztály hozzáadása az adatbázishoz nem sikerült!");
            return response;
        }
    }
}
