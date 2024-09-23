using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedDomainLayer.Repos;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private DbContext _context;
        private IBaseRepo _baseRepo;

        protected IDbContextTransaction? _transaction;

        public virtual IBaseRepo Repository {get => _baseRepo; set => _baseRepo = value; }

        public UnitOfWork(TDbContext context, IBaseRepo repo) 
        {
            _context = context;
            _baseRepo = repo;
        }

        public void SetRepository(IBaseRepo repository)
        {
            if (repository is not null)
                _baseRepo = repository;
        }

        public virtual void Commit()
        {
            try
            {
                _context.SaveChanges();
                _transaction?.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex) { }
            return 0;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }


    }
}