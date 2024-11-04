using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Repos;
using Shared.ApplicationLayer.Repos.UnitOfWork;
using Shared.DomainLayer.Entities;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.UnifOfWorks
{
    public class WrapperUnitOfWork<TDbContext> : UnitOfWork<TDbContext>, IWrapperUnitOfWork where TDbContext : DbContext
    {
        protected Dictionary<Type, object> _repositories;

        public WrapperUnitOfWork(TDbContext dbContext, IBaseDbRepo repository) : base(dbContext)
        {
            _repositories = [];
        }

        public TRepository? AddRepository<TRepository, TEntity>(TRepository? repository) where TRepository : IBaseDbRepo where TEntity : class, IDbEntity<TEntity>, new()
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

        public TRepository? GetRepository<TRepository, TEntity>() where TRepository : IBaseDbRepo where TEntity : class, IDbEntity<TEntity>, new()
        {
            var type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
            {
                return (TRepository)_repositories[type];
            }
            return default;
        }
    }
}
