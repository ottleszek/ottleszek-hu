using WillBeThere.Shared.Responses;
using System.Diagnostics;
using WillBeThere.Shared.Assamblers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Net;
using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.HttpService.HttpService
{
    public class BaseHttpService<TEntityDto> :  IBaseHttpService<TEntityDto> where TEntityDto : class, new()
    {
        protected readonly HttpClient? _httpClient;

        public BaseHttpService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
            }
        }

        public async Task<List<TEntity>> SelectAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            Assambler<TEntity, TEntityDto> _assambler = new Assambler<TEntity, TEntityDto>();
            if (_httpClient is not null)
            {
                try
                {

                    List<TEntityDto>? resultDto = await _httpClient.GetFromJsonAsync<List<TEntityDto>>($"api/{GetApiName<TEntity>()}");
                    if (resultDto is not null)
                    {
                        List<TEntity> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<TEntity>();
        }

        public Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
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

        public async Task<Response> DeleteAsync<TEntity>(TEntity? entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (entity is not null && entity.HasId)
            {
                return await DeleteAsync<TEntity>(entity.Id);
            }
            else
                return new Response($"A {entity} entitásnak nincs azonosítója, nem lehet törölni!");
        }



        public async Task<Response> InsertAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Assambler<TEntity, TEntityDto> _assambler = new Assambler<TEntity, TEntityDto>();
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync($"api/{GetApiName<TEntity>()}", _assambler.ToDto(entity));
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

        public async Task<Response> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IDbEntity<TEntity>, new()
        {
            Response defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    Assambler<TEntity, TEntityDto> _assambler = new Assambler<TEntity, TEntityDto>();
                    HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync($"api/{GetApiName<TEntity>()}", _assambler.ToDto(entity));
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