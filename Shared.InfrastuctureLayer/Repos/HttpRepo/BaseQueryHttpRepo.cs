using System.Diagnostics;
using System.Net.Http.Json;
using Shared.DomainLayer.Entities;
using Shared.ApplicationLayer.Repos.Queries;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base
{
    public class BaseQueryHttpRepo : IQueryGenericMethodRepo
    {
        protected readonly HttpClient? _httpClient;

        public BaseQueryHttpRepo()
        {
            _httpClient = new HttpClient();
        }
        public BaseQueryHttpRepo(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
            }
        }

        public async Task<List<TEntityDto>> GetAllAsync<TEntityDto>() where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<TEntityDto>? resultDto = await _httpClient.GetFromJsonAsync<List<TEntityDto>>($"api/{GetApiName<TEntityDto>()}");
                    if (resultDto is not null)
                    {
                        return resultDto;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<TEntityDto>();
        }
        Task<TEntity?> IQueryGenericMethodRepo.GetByIdAsync<TEntity>(Guid id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        Task<bool> IQueryGenericMethodRepo.IsExsistAsync<TEntity>(Guid id)
        {
            throw new NotImplementedException();
        }

        private object GetApiName<TEntityDto>() where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            string result = typeof(TEntityDto).Name;
            if (result.Length<3)
                return result;
            else
                return result.Remove(result.Length - 3);
        }


    }
}
