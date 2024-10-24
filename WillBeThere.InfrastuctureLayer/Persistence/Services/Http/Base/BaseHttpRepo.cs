using Newtonsoft.Json;
using SharedApplicationLayer.Contracts.Services;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Net;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base
{
    public class BaseHttpRepo : IBaseService
    {
        protected readonly HttpClient? _httpClient;

        public BaseHttpRepo()
        {
            _httpClient = new HttpClient();
        }
        public BaseHttpRepo(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
            }
        }

        public Task<TEntityDto?> GetByIdAsync<TEntityDto>(Guid id) where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntityDto>> SelectAllAsync<TEntityDto>() where TEntityDto : class, IDbEntity<TEntityDto>, new()
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

        public async Task<Response> DeleteAsync<TEntityDto>(TEntityDto? entity) where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            return await Task.FromResult(new Response());
        }

        public async Task<Response> DeleteAsync<TEntityDto>(Guid id) where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            Response defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"api/{GetApiName<TEntityDto>()}/{id}");
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<Response>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A törlés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        string? responseMessage = JsonConvert.DeserializeObject<string>(content);
                        if (responseMessage is null)
                        {
                            defaultResponse.ClearAndAdd("A mentés http kérés hibát okozott!");
                        }
                        else return new Response(responseMessage);
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<Response>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A { http kérés hibát okozott!");
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

        public async Task<Response> InsertAsync<TEntityDto>(TEntityDto entityDto) where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            Response defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync($"api/{GetApiName<TEntityDto>()}", entityDto);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<Response>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A mentés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        string? responseMessage = JsonConvert.DeserializeObject<string>(content);
                        if (responseMessage is null)
                        {
                            defaultResponse.ClearAndAdd("A mentés http kérés hibát okozott!");
                        }
                        else return new Response(responseMessage);
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<Response>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A mentés http kérés hibát okozott!");
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

        public async Task<Response> UpdateAsync<TEntityDto>(TEntityDto entityDto) where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            Response defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync($"api/{GetApiName<TEntityDto>()}", entityDto);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<Response>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A módosítás http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        string? responseMessage = JsonConvert.DeserializeObject<string>(content);
                        if (responseMessage is null)
                        {
                            defaultResponse.ClearAndAdd("A mentés http kérés hibát okozott!");
                        }
                        else return new Response(responseMessage);
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<Response>(content);
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
