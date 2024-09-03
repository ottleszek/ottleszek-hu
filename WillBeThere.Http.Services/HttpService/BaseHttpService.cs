using System.Diagnostics;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Net;
using WillBeThere.Domain.Entities.DbIds;
using WillBeThere.Application.Responses;

namespace WillBeThere.HttpService.HttpService
{
    public class BaseHttpService<TEntityDto> :  IBaseHttpService<TEntityDto> where TEntityDto : class, new()
    {
        protected readonly HttpClient? _httpClient;

        public BaseHttpService()
        {
            _httpClient = new HttpClient();
        }
        public BaseHttpService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
            }
        }

        public async Task<List<TEntityDto>> SelectAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (_httpClient is not null)
            {
                try
                {
                    List<TEntityDto>? resultDto = await _httpClient.GetFromJsonAsync<List<TEntityDto>>($"api/{GetApiName<TEntity>()}");
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

        public Task<TEntityDto?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/{GetApiName<TEntity>()}/{id}");
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A törlés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A módosítás http kérés hibát okozott!");
                        }
                        else return response;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            defaultResponse.ClearAndAdd("Az adatok törlése nem lehetséges!");
            return defaultResponse;
        }

        public async Task<Response> InsertAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new()
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync($"api/{GetApiName<TEntity>()}",entityDto);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A mentés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A módosítás http kérés hibát okozott!");
                        }
                        else return response;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            defaultResponse.ClearAndAdd("Az adatok mentése nem lehetséges!");
            return defaultResponse;
        }

        public async Task<Response> UpdateAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync($"api/{GetApiName<TEntity>()}", entityDto);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A módosítás http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A módosítás http kérés hibát okozott!");
                        }
                        else return response;
                    }
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            defaultResponse.ClearAndAdd("Az adatok frissítés nem lehetséges!");
            return defaultResponse;
        }

        private static string GetApiName<TEntity>() where TEntity : class, new()
        {
            return new TEntity().GetType().Name;
        }
    }
}