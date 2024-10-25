using Microsoft.EntityFrameworkCore;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.InfrastuctureLayer.Repos.DataBase.Commands
{
    public class BaseManyCommandDbRepo<TDbContext> : BaseDbRepo<TDbContext> where TDbContext : DbContext
    {
        public BaseManyCommandDbRepo(TDbContext? dbContext) : base(dbContext) { }
        public Task<Response> UpdateMany<TEntity>(List<TEntity> entities) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response response = new();

            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
            {
                response.Append($"{nameof(BaseManyCommandDbRepo<TDbContext>)} osztály, {nameof(UpdateMany)} metódusban hiba keletkezett!");
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
            response.Append($"{nameof(BaseManyCommandDbRepo<TDbContext>)} osztály, {nameof(UpdateMany)} metódusban hiba keletkezett!");
            response.Append($"{nameof(TEntity)} típusú és {entities.Count} db elem mentése az adatbázisba nem sikerült!");
            return Task.FromResult(response);
        }
    }
}
