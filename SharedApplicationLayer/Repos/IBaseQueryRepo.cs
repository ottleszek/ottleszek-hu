using SharedDomainLayer.Entities;

namespace SharedApplicationLayer.Repos
{
    public interface IBaseQueryRepo
    {
        IQueryable<TEntity> SelectAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        TEntity? GetById<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
