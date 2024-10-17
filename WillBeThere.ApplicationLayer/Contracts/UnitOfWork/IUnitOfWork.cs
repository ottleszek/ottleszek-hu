using SharedApplicationLayer.Repos;

namespace WillBeThere.ApplicationLayer.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //public IBaseCommandRepo? Repository { get; }
        //public void SetRepository(IBaseCommandRepo? repository);
        void Commit();
        Task<int> SaveChangesAsync();
        void BeginTransaction();
        public void Rollback();

    }
}
