using WillBeThere.Domain.Entities.DbIds;

namespace WillBeThere.Domain.DataBroker
{
    public interface IIncludedDataBroker : IDataBroker
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
