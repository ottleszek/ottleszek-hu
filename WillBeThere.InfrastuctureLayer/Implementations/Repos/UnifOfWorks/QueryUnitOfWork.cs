using Microsoft.EntityFrameworkCore;
using SharedApplicationLayer.Repos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks
{
    public class QueryUnitOfWork<TDbContext> : UnitOfWork<TDbContext> where TDbContext : DbContext
    {
        public QueryUnitOfWork(TDbContext context, IBaseRepo repo) : base(context)
        {
        }

        public override void Commit()
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

        public override Task<int> SaveChangesAsync()
        {
            Commit();
            return Task.FromResult(0);
        }
    }
}
