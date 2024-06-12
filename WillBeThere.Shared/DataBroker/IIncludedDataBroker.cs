using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.DataBroker
{
    public interface IIncludedDataBroker
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}
