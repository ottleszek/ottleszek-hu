namespace Shared.ApplicationLayer.Repos.Queries
{
    public interface IQueryGenericRepo<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        public Task<bool> IsExsistAsyn(Guid id);
    }
}
