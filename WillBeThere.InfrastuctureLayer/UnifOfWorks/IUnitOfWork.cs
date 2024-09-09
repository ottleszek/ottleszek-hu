using WillBeThere.DomainLayer.Entities.DbIds;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;
 
namespace WillBeThere.InfrastuctureLayer.UnifOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository? GetRepository<TRepository, TEntity>() where TRepository : IBaseRepo, IRepositoryBase where TEntity : class, IDbEntity<TEntity>, new();
        //TRepository? CreateRepository<TRepository, TEntity>() where TRepository : IBaseRepo, IRepositoryBase where TEntity : class, IDbEntity<TEntity>, new();
        void AddRepository<TRepository, TEntity>(TRepository? repository) where TRepository : IBaseRepo, IRepositoryBase where TEntity : class, IDbEntity<TEntity>, new();

        Task SaveAsync();
    }
}
