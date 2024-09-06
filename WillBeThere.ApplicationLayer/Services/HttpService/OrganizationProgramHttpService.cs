using System.Diagnostics;
using System.Net.Http.Json;
using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.ApplicationLayer.Dtos.ResultModels;

namespace WillBeThere.ApplicationLayer.Services.HttpService
{
    public class OrganizationProgramHttpService : BaseHttpService<OrganizationProgramDto>, IOrganizationProgramHttpService
    {
        public OrganizationProgramHttpService(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<List<PublicOrganizationProgramDto>> GetAllPublicOrganizationProgramsAsync()
        {

            if (_httpClient is not null)
            {
                try
                {
                    List<PublicOrganizationProgramDto>? resultDto = await _httpClient.GetFromJsonAsync<List<PublicOrganizationProgramDto>>($"/api/OrganizationProgram/publicprograms");
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
            return new List<PublicOrganizationProgramDto>();
        }
    }
}
