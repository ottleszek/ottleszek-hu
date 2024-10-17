﻿using Newtonsoft.Json;
using SharedApplicationLayer.Contracts.Persistence;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http
{
    public class HttpPersistenceService : IHttpPersistenceService
    {
        protected readonly HttpClient? _httpClient;
        public HttpPersistenceService()
        {
            _httpClient = new HttpClient();
        }


        public HttpPersistenceService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
            }
        }
        public async Task<Response> SaveMany<TEntityDto>(List<TEntityDto> dtoEntities) where TEntityDto : class, IDbEntity<TEntityDto>, new()
        {
            Response defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync($"api/{GetApiName<TEntityDto>()}/bulk", dtoEntities);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        Response? response = JsonConvert.DeserializeObject<Response>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAdd("A tömeges mentés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        string? responseMessage = JsonConvert.DeserializeObject<string>(content);
                        if (responseMessage is null)
                        {
                            defaultResponse.ClearAndAdd("A tömeges mentés http kérés hibát okozott!");
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
                            defaultResponse.ClearAndAdd("A tömeges mentés http kérés hibát okozott!");
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

        private static string GetApiName<TEntity>() where TEntity : class, new()
        {
            return new TEntity().GetType().Name;
        }
    }
}
