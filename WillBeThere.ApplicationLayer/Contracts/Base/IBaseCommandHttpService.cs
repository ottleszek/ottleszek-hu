using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace WillBeThere.ApplicationLayer.Contracts.Base
{
    public interface IBaseCommandHttpService<TEntityDto> where TEntityDto : class, new()
    {
        Task<Response> InsertAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> UpdateAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
