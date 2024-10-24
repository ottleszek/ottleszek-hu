using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.ApplicationLayer.Repos.Commands
{
    public interface IGenericCommandRepo<TEntity> where TEntity : class, IDbEntity<TEntity>, new()
    {
        public Task<List<TEntity>> SelectAsync();
        public Task<TEntity?> GetByIdAsync(Guid id);
        public Task<Response> UpdateAsync(TEntity entity);
        public Task<Response> DeleteAsync(TEntity entity);
        public Task<Response> DeleteAsync(Guid id);
        public Task<Response> InsertAsync(TEntity entity);
    }
}
