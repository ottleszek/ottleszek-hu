using WillBeThere.Domain.Entities.DbIds;

namespace WillBeThere.Infrastucture.DataBrokers
{
    public interface IIncludedDataBroker : IDataBroker
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
