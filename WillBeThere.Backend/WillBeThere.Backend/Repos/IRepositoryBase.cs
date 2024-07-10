using System.Linq.Expressions;
using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Backend.Repos
{
    public interface IRepositoryBase
    {
        IQueryable<TEntity> FindAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        IQueryable<TEntity> FindByCondition<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
