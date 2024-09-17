using SharedDomainLayer.Entities;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.Base
{
    public interface IIncludedQueryRepo : IBaseQueryRepo
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
