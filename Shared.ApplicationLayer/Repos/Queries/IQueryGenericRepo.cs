using Shared.DomainLayer.Entities;

namespace Shared.ApplicationLayer.Repos.Queries
{
    public interface IQueryGenericRepo<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        public Task<bool> IsExsistAsyn(Guid id);
    }

    public interface IQueryGenericRepo<TModel, TDto>
        where TModel : class, IDbEntity<TModel>, new()
        where TDto : class, IDbEntity<TDto>, new()
    {
        Task<List<TModel>> GetAllAsync();
        Task<TModel?> GetByIdAsync(Guid id);
        public Task<bool> IsExsistAsync(Guid id);
    }
}
