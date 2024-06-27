using WillBeThere.Backend.Repos;
using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.DataBroker
{
    public interface IIncludedDataBroker : IDataBroker
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
