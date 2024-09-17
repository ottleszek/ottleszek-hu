using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace WillBeThere.InfrastuctureLayer.DataBrokers.Commands
{
    public interface IBaseCommandBroker
    {
        Task<Response> InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
