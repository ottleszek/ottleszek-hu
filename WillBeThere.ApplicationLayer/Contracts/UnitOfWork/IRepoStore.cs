using Shared.ApplicationLayer.Repos;
using Shared.DomainLayer.Entities;

namespace WillBeThere.ApplicationLayer.Contracts.UnitOfWork
{
    public interface IRepoStore
    {
        TRepository? AddRepository<TRepository, TEntity>(TRepository? repository) where TRepository : IBaseDbRepo where TEntity : class, IDbEntity<TEntity>, new();
        TRepository? GetRepository<TRepository, TEntity>() where TRepository : IBaseDbRepo where TEntity : class, IDbEntity<TEntity>, new();
    }
}
