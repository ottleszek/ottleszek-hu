using SharedDomainLayer.Entities;

namespace SharedApplicationLayer.Repos
{
    public interface IIncludedQueryRepo : IBaseQueryRepo
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
