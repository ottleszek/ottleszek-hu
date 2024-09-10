using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WillBeThere.DomainLayer.Entities.DbIds;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.UnifOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IDbContextTransaction? _transaction;

        private Dictionary<Type, object> _repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public TRepository? GetRepository<TRepository, TEntity>() where TRepository : IBaseRepo, IRepositoryBase where TEntity : class, IDbEntity<TEntity>, new()
        {
            var type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
            {
                return (TRepository)_repositories[type];
            }
            return default;
        }
        public void AddRepository<TRepository, TEntity>(TRepository? repository) where TRepository : IBaseRepo, IRepositoryBase where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (repository is null)
                return;
            TRepository? exsist = GetRepository<TRepository, TEntity>();
            if (exsist == null)
            {
                var repositoryType = typeof(TRepository);
                _repositories.Add(repositoryType, repository);
            }
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

        public void BeginTransaction()
        {
            _transaction =_context.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
                _transaction?.Commit();
            }
            catch 
            {
                Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }
    }
}