using Newtonsoft.Json;
using Shared.ApplicationLayer.Persistence;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http
{
    public class ManyDataHttpPersistenceService : IManyDataPersistenceService
    {
        protected readonly HttpClient? _httpClient;

        public ManyDataHttpPersistenceService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
            }
        }
        public async Task<Response> UpdateMany<TEntityDto>(List<TEntityDto> dtoEntities) where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            Response defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    string apiName=GetApiName<TEntityDto>();
                    if (string.IsNullOrEmpty(apiName))
                    {
                        Debug.WriteLine($"{nameof(ManyDataHttpPersistenceService)} osztály, {nameof(UpdateMany)} metódusa {nameof(TEntityDto)} osztály esetén hiba történt!");
                        Debug.WriteLine($"Api név elkészítése api híváshoz nem sikerült!");
                    }
                    HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync($"api/{apiName}/bulk", dtoEntities);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<Response>(content);
                        if (response is null)
                        {
                            Debug.WriteLine($"{nameof(ManyDataHttpPersistenceService)} osztály, {nameof(UpdateMany)} metódusa {nameof(TEntityDto)} osztály esetén hiba történt!");
                            Debug.WriteLine($"Api válasz nem jött meg!");
                            defaultResponse.ClearAndAdd("A mentés nem sikerült");
                        }
                        else return response;
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        string? responseMessage = JsonConvert.DeserializeObject<string>(content);
                        if (responseMessage is null)
                        {
                            Debug.WriteLine($"{nameof(ManyDataHttpPersistenceService)} osztály, {nameof(UpdateMany)} metódusa {nameof(TEntityDto)} osztály esetén hiba történt!");
                            Debug.WriteLine($"{nameof(HttpStatusCode.InternalServerError)} hiba keletkezett!");
                            Debug.WriteLine($"{responseMessage}");
                            defaultResponse.ClearAndAdd("A mentés nem sikerült");
                        }
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        Debug.WriteLine($"{nameof(ManyDataHttpPersistenceService)} osztály, {nameof(UpdateMany)} metódusa {nameof(TEntityDto)} osztály esetén hiba történt!");
                        Debug.WriteLine($"{nameof(httpResponse.StatusCode)} hiba keletkezett!");
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<Response>(content);
                        if (response is null)
                        {
                            Debug.WriteLine($"{nameof(ManyDataHttpPersistenceService)} osztály, {nameof(UpdateMany)} metódusa {nameof(TEntityDto)} osztály esetén hiba történt!");
                            Debug.WriteLine($"A RestApi válasz elérhetetlen (null)!");
                        }
                        else if (response.IsSuccess)
                            return response;
                        else
                        {
                            Debug.WriteLine($"A RestApi hibát adott!");
                            Debug.WriteLine($"{response.Error}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            defaultResponse.ClearAndAdd("A mentés nem sikerült");
            return defaultResponse;
        }

        private static string GetApiName<TEntity>() where TEntity : class, new()
        {
            string apiNameWithDto = new TEntity().GetType().Name;
            if (apiNameWithDto.Length < 3)
                return string.Empty;
            else
                return apiNameWithDto.Remove(apiNameWithDto.Length-3);
        }
    }
}
