using WillBeThere.DomainLayer.Entities.DbIds;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        Task Commit();

        Task<int> SaveChanges();

        TRepository? GetRepository<TRepository, TEntity>() where TRepository : IBaseCommandRepo where TEntity : class, IDbEntity<TEntity>, new();
        //TRepository? CreateRepository<TRepository, TEntity>() where TRepository : IBaseRepo, IRepositoryBase where TEntity : class, IDbEntity<TEntity>, new();
        void AddRepository<TRepository, TEntity>(TRepository? repository) where TRepository : IBaseCommandRepo where TEntity : class, IDbEntity<TEntity>, new();
    }
}
