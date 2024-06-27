using System.Linq.Expressions;
using WillBeThere.Shared.Models.DbIds;
using WillBeThere.Shared.Responses;

namespace WillBeThere.Backend.Repos
{
    public interface IDataBroker
    {
        Task<List<TEntity>> SelectAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();   
        Task<TEntity?> GetByIdAsync<TEntity>(DbId id) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(DbId id) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
