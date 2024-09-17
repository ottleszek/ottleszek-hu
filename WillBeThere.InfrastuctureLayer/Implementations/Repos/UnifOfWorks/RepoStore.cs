using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Repos;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks
{
    public class RepoStore<TDbContext> : IRepoStore where TDbContext : DbContext
    {
        protected Dictionary<Type, object> _repositories;

        public RepoStore()
        {
            _repositories = [];
        }

        public TRepository? AddRepository<TRepository, TEntity>(TRepository? repository) where TRepository : IBaseRepo where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (repository is not null)
            {
                TRepository? exsist = GetRepository<TRepository, TEntity>();
                if (exsist == null)
                {
                    var repositoryType = typeof(TRepository);
                    _repositories.Add(repositoryType, repository);
                    return repository;
                }
            }
            return default;
        }

        public TRepository? GetRepository<TRepository, TEntity>() where TRepository : IBaseRepo where TEntity : class, IDbEntity<TEntity>, new()
        {
            var type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
            {
                return (TRepository)_repositories[type];
            }
            return default;
        }

        /*TRepository? IUnitOfWork.CreateRepository<TRepository, TEntity>() where TRepository : class
{
    TRepository? repository = GetRepository<TRepository, TEntity>();
    if (repository!=null)
        return repository;
    else
    {
        var repositoryType = typeof(TRepository);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        if (repositoryInstance == null)
            return null;
        var type = typeof(TEntity);
        _repositories.Add(type, repositoryInstance);
        return (TRepository)_repositories[type];
    }
}
*/

    }
}
