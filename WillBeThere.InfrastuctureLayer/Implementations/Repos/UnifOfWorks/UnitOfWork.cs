using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks
{
    public class UnitOfWork<TDbContext> : WrapperUnitOfWork<TDbContext>, IUnitOfWork where TDbContext : DbContext
    {
        public UnitOfWork(TDbContext context) : base(context)  
        {
            _repositories = new Dictionary<Type, object>();
        }

        public override void Commit()
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

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex) { }
            return 0;
        }

    }
}