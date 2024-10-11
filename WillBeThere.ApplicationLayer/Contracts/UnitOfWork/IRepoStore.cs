using SharedApplicationLayer.Repos;
using SharedDomainLayer.Entities;
namespace WillBeThere.ApplicationLayer.Contracts.UnitOfWork
{
    public interface IRepoStore
    {
        TRepository? AddRepository<TRepository, TEntity>(TRepository? repository) where TRepository : IBaseRepo where TEntity : class, IDbEntity<TEntity>, new();
        TRepository? GetRepository<TRepository, TEntity>() where TRepository : IBaseRepo where TEntity : class, IDbEntity<TEntity>, new();
    }
}
