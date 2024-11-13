using Shared.ApplicationLayer.Transformers;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.ApplicationLayer.Repos.Commands
{
    public interface ICommandGenericRepo<TEntity> where TEntity : class, IDbEntity<TEntity>, new()
    {
        public Task<Response> UpdateAsync(TEntity entity);
        public Task<Response> DeleteAsync(TEntity entity);
        public Task<Response> DeleteAsync(Guid id);
        public Task<Response> InsertAsync(TEntity entity);
    }

    public interface ICommandGenericRepo<TModel, TDto> 
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
        public Task<Response> UpdateAsync(TModel entity);
        public Task<Response> DeleteAsync(TModel entity);
        public Task<Response> DeleteAsync(Guid id);
        public Task<Response> InsertAsync(TModel entity);
    }
}
