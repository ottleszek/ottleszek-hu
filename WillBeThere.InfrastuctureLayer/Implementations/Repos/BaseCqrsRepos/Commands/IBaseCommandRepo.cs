using WillBeThere.ApplicationLayer.Responses;
using WillBeThere.DomainLayer.Entities.DbIds;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands
{
    public interface IBaseCommandRepo
    {
        public Response UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        public Response DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new();
        public Response DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        public Response InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
