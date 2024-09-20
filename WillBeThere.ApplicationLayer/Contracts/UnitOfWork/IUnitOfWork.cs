using SharedDomainLayer.Repos;

namespace WillBeThere.ApplicationLayer.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepo Repository { get; }
        void Commit();
        Task<int> SaveChangesAsync();
        void BeginTransaction();
        public void Rollback();

    }
}
