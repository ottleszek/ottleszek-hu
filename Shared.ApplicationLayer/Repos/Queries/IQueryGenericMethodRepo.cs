using Shared.DomainLayer.Entities;

namespace Shared.ApplicationLayer.Repos.Queries
{
    public interface IQueryGenericMethodRepo 
    {
        Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        public Task<bool> IsExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
