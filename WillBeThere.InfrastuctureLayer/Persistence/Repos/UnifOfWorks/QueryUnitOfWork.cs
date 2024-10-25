using Microsoft.EntityFrameworkCore;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.UnifOfWorks
{
    public class QueryUnitOfWork<TDbContext> : UnitOfWork<TDbContext> where TDbContext : DbContext
    {
        public QueryUnitOfWork(TDbContext context, IBaseDbRepo repo) : base(context)
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
