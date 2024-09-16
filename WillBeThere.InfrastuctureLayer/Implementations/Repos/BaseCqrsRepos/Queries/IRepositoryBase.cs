using SharedDomainLayer.Entities;
using System.Linq.Expressions;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries
{
    public interface IRepositoryBase
    {
        IQueryable<TEntity> FindAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        IQueryable<TEntity> FindByCondition<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
