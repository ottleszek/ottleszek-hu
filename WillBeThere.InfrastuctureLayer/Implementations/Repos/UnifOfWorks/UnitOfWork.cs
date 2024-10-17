using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedApplicationLayer.Repos;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private DbContext _context;
        private IBaseCommandRepo? _baseCommandRepo;

        protected IDbContextTransaction? _transaction;

        //public virtual IBaseCommandRepo? Repository {get => _baseCommandRepo; set => _baseCommandRepo = value; }

        public UnitOfWork(TDbContext context) 
        {
            _context = context;
        }
        /*        public void SetRepository(IBaseCommandRepo? baseCommandRepo)
        {
            if (baseCommandRepo is not null)
                _baseCommandRepo = baseCommandRepo;
        }
        */
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