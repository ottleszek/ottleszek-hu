using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace SharedApplicationLayer.Repos
{
    public interface IBaseCommandRepo<TEntityDto> where TEntityDto : class, new()
    {
        Task<Response> InsertAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> UpdateAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
