using SharedApplicationLayer.Repos;

namespace WillBeThere.ApplicationLayer.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepo Repository { get; }
        public void SetRepository(IBaseRepo repository);
        void Commit();
        Task<int> SaveChangesAsync();
        void BeginTransaction();
        public void Rollback();

    }
}
