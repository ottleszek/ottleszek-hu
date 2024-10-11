using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;
using System.Linq.Expressions;

namespace SharedApplicationLayer.Repos
{
    public interface INoCqrsRepo
    {
        IQueryable<TEntity> FindByCondition<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IDbEntity<TEntity>, new();
        IQueryable<TEntity> FindAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();

        Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        
        Task<Response> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
    } 
}
