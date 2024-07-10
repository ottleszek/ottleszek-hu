using WillBeThere.HttpService.HttpService;
using WillBeThere.Shared.Models.Guids;
using WillBeThere.Shared.Responses;

namespace WillBeThere.HttpService.DataService
{
    public class BaseDataService<TEntity, TEntityDto> : IBaseDataService<TEntity,TEntityDto>
        where TEntity : class, IDbEntity<TEntity>, new()
        where TEntityDto : class, new()
    {
        protected IBaseHttpService<TEntityDto> _httpService;

        public BaseDataService(IBaseHttpService<TEntityDto> httpService)
        {

            _httpService = httpService;
        }

        public async Task<List<TEntity>> SelectAsync() 
        {
            return await _httpService.SelectAsync<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id) 
        {
            return await _httpService.GetByIdAsync<TEntity>(id);
        }

        public async Task<Response> UpdateAsync(TEntity entity)
        {
           return await _httpService.UpdateAsync<TEntity>(entity);
        }

        public async Task<Response> DeleteAsync(TEntity entity)
        {
            return await _httpService.DeleteAsync<TEntity>(entity);
        }


        public async Task<Response> DeleteAsync(Guid id)
        {
           return await _httpService.DeleteAsync<TEntity>(id);
        }

        public async Task<Response> InsertAsync(TEntity entity)
        {
            return await _httpService.InsertAsync<TEntity>(entity);
        }
    }
}