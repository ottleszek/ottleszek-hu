namespace WillBeThere.ApplicationLayer.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IWrapperUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
