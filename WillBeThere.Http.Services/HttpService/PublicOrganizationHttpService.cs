using System.Diagnostics;
using System.Net.Http.Json;
using WillBeThere.Shared.Assamblers;
using WillBeThere.Shared.Assamblers.ResultModels;
using WillBeThere.Shared.Dtos.ResultModels;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.HttpService.HttpService
{
    public class PublicOrganizationHttpService : IPublicOrganizationHttpService
    {
        private readonly HttpClient? _httpClient;
        private readonly Assambler<PublicOrganizationProgram, PublicOrganizationProgramDto>? _assambler;

        public PublicOrganizationHttpService(IHttpClientFactory? httpClientFactory, PublicOrganizationProgramAssambler assambler)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("WillBeThere");
                _assambler = assambler;
            }
        }
        public async Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync()
        {
           
            if (_httpClient is not null && _assambler is not null)
            {
                try
                {

                    List<PublicOrganizationProgramDto>? resultDto = await _httpClient.GetFromJsonAsync<List<PublicOrganizationProgramDto>>($"/api/OrganizationProgram/publicprograms");
                    if (resultDto is not null)
                    {
                        List<PublicOrganizationProgram> result = resultDto.Select(entity => _assambler.ToModel(entity)).ToList();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<PublicOrganizationProgram>();
        }
    }
}
