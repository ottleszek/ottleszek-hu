using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;

namespace Shared.ApplicationLayer.Repos.Commands
{
    public interface ICommandGenericMethodRepo : IBaseDbRepo
    {
        public Response Update<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
        public Response Delete<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new();
        public Response Delete<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        public Response Insert<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
