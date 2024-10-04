
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;


namespace WillBeThere.ApplicationLayer.Contracts.Base
{
    public interface IBaseQueryHttpService<TEntityDto> where TEntityDto : class, new()
    {
        Task<List<TEntityDto>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        Task<TEntityDto?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
