using WillBeThere.Shared.Models.Guids;
using WillBeThere.Shared.Responses;

namespace WillBeThere.Shared.DataBroker
{
    public interface IDtoDataBroker<TEntityDto> where TEntityDto : class, new() 
    {
        Task<List<TEntityDto>> SelectAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        Task<TEntityDto?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> InsertAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> UpdateAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
