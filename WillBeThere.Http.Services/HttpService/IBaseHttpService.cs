using WillBeThere.Shared.DataBroker;
using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.HttpService.HttpService
{
    public interface IBaseHttpService : IDataBroker
    {
        public Task<List<TEntity>> SelectAsync<TEntity, TEntityDto>()
            where TEntity : class, IDbEntity<TEntity>, new()
            where TEntityDto : class, new();
    }
}
