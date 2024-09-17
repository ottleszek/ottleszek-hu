using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks
{
    public class WrapperUnitOfWork<TDbContext> : RepoStore<TDbContext>, IWrapperUnitOfWork where TDbContext : DbContext
    { 
        protected readonly TDbContext _context;
        protected IDbContextTransaction? _transaction;

        public WrapperUnitOfWork(TDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public virtual void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
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
