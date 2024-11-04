namespace Shared.ApplicationLayer.Repos.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //public IBaseCommandRepo? Repository { get; }
        //public void SetRepository(IBaseCommandRepo? repository);
        void Commit();
        Task<int> SaveChangesAsync();
        void BeginTransaction();
        public Task BeginTransactionAsync();
        public void Rollback();

    }
}
