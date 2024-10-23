using System.Diagnostics;
using System.Net.Http.Json;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.DomainLayer.Repos;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.Http
{
    public class HttpOrganizationProgramRepo : IOrganizationProgramRepo
    {
        protected readonly HttpClient _httpClient;
        public HttpOrganizationProgramRepo(IHttpClientFactory? httpClientFactory)
        {
            _httpClient = httpClientFactory?.CreateClient("WillBeThere") ?? throw new ArgumentNullException(nameof(httpClientFactory), $"{nameof(HttpOrganizationProgramRepo)} osztályban http kliens inicizalizálása nem sikerült!");
        }

        public async Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationsProgramsAsync()
        {
            try
            {
                List<PublicOrganizationProgramDto>? resultDto = await _httpClient.GetFromJsonAsync<List<PublicOrganizationProgramDto>>($"/api/OrganizationProgram/publicprograms");
                if (resultDto is not null)
                {
                    return resultDto.Select(dto => dto.ToModel()).ToList();
                }
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"HTTP Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new List<PublicOrganizationProgram>();
        }
    }
}
