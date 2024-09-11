using WillBeThere.DomainLayer.Entities.DbIds;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries
{
    public interface IBaseQueryRepo
    {
        public  Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        public  Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        public Task<bool> ExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();



    }
}
