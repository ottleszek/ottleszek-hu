using SharedDomainLayer.Entities;
using SharedDomainLayer.Repos.Commands;

namespace SharedDomainLayer.WrapRepos
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        Task Commit();

        Task<int> SaveChangesAsync();

        TRepository? GetRepository<TRepository, TEntity>() where TRepository : IBaseCommandRepo where TEntity : class, IDbEntity<TEntity>, new();
        //TRepository? CreateRepository<TRepository, TEntity>() where TRepository : IBaseRepo, IRepositoryBase where TEntity : class, IDbEntity<TEntity>, new();
        TRepository? AddRepository<TRepository, TEntity>(TRepository? repository) where TRepository : IBaseCommandRepo where TEntity : class, IDbEntity<TEntity>, new();
    }
}
