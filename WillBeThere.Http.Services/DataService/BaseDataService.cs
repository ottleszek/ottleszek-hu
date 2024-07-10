using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Net;
using WillBeThere.Shared.DataBroker;
using WillBeThere.Shared.Models.DbIds;
using WillBeThere.Shared.Responses;
using WillBeThere.HttpService.HttpService;

namespace WillBeThere.HttpService.DataService
{
    public class BaseDataService<TEntity, TEntityDto> : IBaseDataService<TEntity,TEntityDto>
        where TEntity : class, IDbEntity<TEntity>, new()
        where TEntityDto : class, new()
    {
        protected IBaseHttpService _httpService;

        public BaseDataService(IBaseHttpService httpService)
        {

            _httpService = httpService;
        }

        public async Task<List<TEntity>> SelectAsync() 
        {
            return await _httpService.SelectAsync<TEntity,TEntityDto>();
        }

        public async Task<TEntity?> GetByIdAsync(DbId id) 
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


        public async Task<Response> DeleteAsync(DbId id)
        {
           return await _httpService.DeleteAsync<TEntity>(id);
        }

        public async Task<Response> InsertAsync(TEntity entity)
        {
            return await _httpService.InsertAsync<TEntity>(entity);
        }




    }
}