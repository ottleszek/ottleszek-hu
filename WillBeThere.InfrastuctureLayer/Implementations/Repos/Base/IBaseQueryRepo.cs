using SharedDomainLayer.Entities;
using SharedDomainLayer.Repos;
using SharedDomainLayer.Repos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.Base
{
    public interface IBaseQueryRepo : IBaseRepo, IRepositoryBase
    {
        public Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        public Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        public Task<bool> IsExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
