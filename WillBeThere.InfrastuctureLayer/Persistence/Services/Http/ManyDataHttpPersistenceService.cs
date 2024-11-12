using Newtonsoft.Json;
using Shared.ApplicationLayer.Persistence;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http
{
    public class ManyDataHttpPersistenceService : IManyDataPersistenceService
    {
        protected readonly HttpClient _httpClient;

        public ManyDataHttpPersistenceService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WillBeThere") ?? throw new ArgumentNullException(nameof(httpClientFactory));

        }
        public async Task<Response> UpdateMany<TEntityDto>(List<TEntityDto> dtoEntities) where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            Response response = new();

            if (string.IsNullOrEmpty(GetApiName<TEntityDto>()))
            {
                Debug.WriteLine($"{nameof(ManyDataHttpPersistenceService)} osztály, {nameof(UpdateMany)} metódusa {nameof(TEntityDto)} osztály esetén hiba történt!");
                Debug.WriteLine($"Api név elkészítése api híváshoz nem sikerült!");
            }

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync($"api/{GetApiName<TEntityDto>()}/bulk", dtoEntities);
                response = await HandleErrorResponse(httpResponse, response);

                string content = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<Response>(content);
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            response.ClearAndAddError("A mentés nem sikerült");
            return response;
        }

        private async Task<Response> HandleErrorResponse(HttpResponseMessage httpResponse, Response response)
        {
            string content = await httpResponse.Content.ReadAsStringAsync();
            if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                var badRequestResponse = JsonConvert.DeserializeObject<Response>(content);
                if (badRequestResponse is null)
                {
                    Debug.WriteLine($"{nameof(ManyDataHttpPersistenceService)} osztály, {nameof(UpdateMany)} metódusában hiba történt! A backend válasz nem értelmehzető!");
                }
                return badRequestResponse ?? response.ClearAndAddError("A mentés nem sikerült"); ;
            }

            else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                string? responseMessage = JsonConvert.DeserializeObject<string>(content);
                if (responseMessage is null)
                {
                    Debug.WriteLine($"{nameof(ManyDataHttpPersistenceService)} osztály, {nameof(UpdateMany)} metódusa esetén hiba történt! A backend válasz nem értelmezhető!");
                }
                Debug.WriteLine($"{nameof(HttpStatusCode.InternalServerError)} hiba keletkezett!");
                Debug.WriteLine($"{responseMessage}");
                response.ClearAndAddError("A mentés nem sikerült");
            }
            else if (!httpResponse.IsSuccessStatusCode)
            {
                Debug.WriteLine($"{nameof(ManyDataHttpPersistenceService)} osztály, {nameof(UpdateMany)} metódusa {nameof(TEntityDto)} osztály esetén hiba történt!");
                Debug.WriteLine($"{nameof(httpResponse.StatusCode)} hiba keletkezett!");
                httpResponse.EnsureSuccessStatusCode();
            }
        }

        private static string GetApiName<TEntity>() where TEntity : class, new()
        {
            string apiNameWithDto = new TEntity().GetType().Name;
            if (apiNameWithDto.Length < 3)
                return string.Empty;
            else
                return apiNameWithDto.Remove(apiNameWithDto.Length - 3);
        }
    }
}
