using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.ApplicationLayer.Repos.Commands
{
    public interface ICommandGenericMethodRepo 
    {
        public Task<Response> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        public Task<Response> DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new();
        public Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        public Task<Response> InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
