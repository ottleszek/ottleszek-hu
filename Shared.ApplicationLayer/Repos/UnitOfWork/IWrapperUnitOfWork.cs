namespace Shared.ApplicationLayer.Repos.UnitOfWork
{
    public interface IWrapperUnitOfWork : IRepoStore
    {
        void BeginTransaction();
        void Commit();
        public void Rollback();
    }
}
