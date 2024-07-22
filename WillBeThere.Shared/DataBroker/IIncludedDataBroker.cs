using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.DataBroker
{
    public interface IIncludedDataBroker : IDataBroker
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
