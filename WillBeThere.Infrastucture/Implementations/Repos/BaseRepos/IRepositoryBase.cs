using System.Linq.Expressions;
using WillBeThere.Domain.Entities.DbIds;

namespace WillBeThere.Infrastucture.Implementations.Repos.BaseRepos
{
    public interface IRepositoryBase
    {
        IQueryable<TEntity> FindAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        IQueryable<TEntity> FindByCondition<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
