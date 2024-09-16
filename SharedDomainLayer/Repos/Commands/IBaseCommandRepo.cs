using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;

namespace SharedDomainLayer.Repos.Commands
{
    public interface IBaseCommandRepo : IBaseRepo, IRepositoryBase
    {
        public Response Update<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        public Response Delete<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new();
        public Response Delete<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        public Response Insert<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
