using SharedDomainLayer.Entities;

namespace SharedApplicationLayer.Repos
{
    public interface IBaseQueryRepo<TEntityDto> where TEntityDto : class, new()
    {
        Task<List<TEntityDto>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        Task<TEntityDto?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
