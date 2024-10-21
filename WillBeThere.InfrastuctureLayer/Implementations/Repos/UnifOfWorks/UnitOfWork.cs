using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private DbContext _context;

        protected IDbContextTransaction? _transaction;

        public UnitOfWork(TDbContext context) 
        {
            _context = context;
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
            catch (Exception ex) 
            { 
                Rollback();
                throw new SaveChangesException("Adatbázis mentési hiba történt.", ex);
            }
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