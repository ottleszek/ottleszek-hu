using WillBeThere.Application.Responses;
using WillBeThere.Domain.Entities.DbIds;

namespace WillBeThere.Domain.DataBroker
{
    public interface IDataBroker
    {
        Task<List<TEntity>> SelectAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
