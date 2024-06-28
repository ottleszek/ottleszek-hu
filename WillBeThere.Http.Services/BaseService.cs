using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using WillBeThere.Backend.Repos;
using WillBeThere.Shared.Assamblers;
using WillBeThere.Shared.Models.DbIds;
using WillBeThere.Shared.Responses;

namespace WillBeThere.HttpService
{
    public class BaseService<TEntity, TEntityDto> : IDataBroker, IBaseService
        where TEntity : class, IDbEntity<TEntity>, new()
        where TEntityDto : class, new()
    {
        protected readonly HttpClient? _httpClient;
        protected Assambler<TEntity, TEntityDto> _assambler;

        public BaseService(IHttpClientFactory? httpClientFactory, Assambler<TEntity, TEntityDto> assambler)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("KretaApi");
            }
            _assambler = assambler;
        }

        public async Task<List<TEntity>> SelectAsync() where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (_httpClient is not null)
            {
                try
                {
                    
                    List<TEntityDto>? resultDto = await _httpClient.GetFromJsonAsync<List<TEntityDto>>($"api/{GetApiName()}");
                    if (resultDto is not null)
                    {
                        List<TEntity> result = resultDto.Select(entity => _assambler.ToModel(entity) ).ToList();
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

        Task<TEntity1> IDataBroker.GetByIdAsync<TEntity1>(DbId id)
        {
            throw new NotImplementedException();
        }

        public async Task<ControllerResponse> UpdateAsync(TEntity entity)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync($"api/{GetApiName()}", _assambler.ToDto(entity));
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
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
            defaultResponse.ClearAndAdd("Az adatok frissítés nem lehetséges!");
            return defaultResponse;
        }

        public async Task<ControllerResponse> DeleteAsync(TEntity entity)
        {
            if (entity.Id.Exsist)
            {
                return await DeleteAsync(entity.Id);
            }
            else
                return new ControllerResponse($"A {entity} entitásnak nincs azonosítója, nem lehet törölni!");
        }


        public async Task<ControllerResponse> DeleteAsync(DbId id)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/{GetApiName()}/{id}");
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
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
            defaultResponse.ClearAndAdd("Az adatok törlése nem lehetséges!");
            return defaultResponse;
        }

        public async Task<ControllerResponse> InsertAsync(TEntity entity)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync( $"api/{GetApiName()}", _assambler.ToDto(entity));
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

        private static string GetApiName()
        {
            return new TEntity().GetType().Name;
        }
    }
}
