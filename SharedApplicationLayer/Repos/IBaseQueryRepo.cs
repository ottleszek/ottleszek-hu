using SharedDomainLayer.Entities;

namespace SharedApplicationLayer.Repos
{
    public interface IBaseQueryRepo : IBaseRepo
    {
        Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        public Task<bool> IsExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
