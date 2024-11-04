using System.Diagnostics;
using System.Net.Http.Json;
using System.Net;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;
using Newtonsoft.Json;
using Shared.ApplicationLayer.Repos.Commands;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base
{
    public class CommandHttpRepo : ICommandGenericMethodRepo
    {
        protected readonly HttpClient? _httpClient;

        public CommandHttpRepo()
        {
            _httpClient = new HttpClient();
        }
        public CommandHttpRepo(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
            }
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

        public async Task<Response> DeleteAsync<TEntityDto>(TEntityDto? entity) where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            if (entity is null)
                return new Response("Az adatok törlése nem lehetséges!");
            return await DeleteAsync<TEntityDto>(entity.Id); 
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

        private string GetApiName<TEntityDto>() where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            string result = typeof(TEntityDto).Name;
            if (result.Length<3)
                return result;
            else
                return result.Remove(result.Length - 3);
        }

    }
}
