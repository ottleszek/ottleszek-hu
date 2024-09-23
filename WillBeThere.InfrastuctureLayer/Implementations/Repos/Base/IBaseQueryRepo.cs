using SharedDomainLayer.Entities;
using SharedDomainLayer.Repos;
using SharedDomainLayer.Repos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.Base
{
    public interface IBaseQueryRepo : IBaseRepo, IRepositoryBase
    {
        IQueryable<TEntity> SelectAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        TEntity GetById<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        bool IsExsist<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
