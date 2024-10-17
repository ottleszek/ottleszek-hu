using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;
using System.Linq.Expressions;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.Base
{
    public static class QuerybleRepo
    {
        public static IQueryable<TEntity> FindAll<TEntity>(this IQueryable<TEntity>? query) where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (query is null)
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            return query.AsNoTracking();
        }
        public static IQueryable<TEntity> FindByCondition<TEntity>(this IQueryable<TEntity>? query, Expression<Func<TEntity, bool>> expression) where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (query is null)
                return Enumerable.Empty<TEntity>().AsQueryable().AsNoTracking();
            return query.Where(expression).AsNoTracking();
        }

        public static TEntity? GetById<TEntity>(this IQueryable<TEntity>? query, Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (query is null)
                return null;
            else
                return query.FirstOrDefault(e => e.Id == id);
        }
    }
}
