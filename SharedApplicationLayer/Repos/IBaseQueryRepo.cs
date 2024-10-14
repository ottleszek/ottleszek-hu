using SharedDomainLayer.Entities;

namespace SharedApplicationLayer.Repos
{
    public interface IBaseQueryRepo
    {
        Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
