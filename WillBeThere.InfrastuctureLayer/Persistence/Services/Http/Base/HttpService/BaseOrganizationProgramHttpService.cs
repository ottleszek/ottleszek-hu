using System.Diagnostics;
using System.Net.Http.Json;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.HttpService
{
    public class BaseOrganizationProgramHttpService : BaseHttpService, IBaseOrganizationProgramHttpService
    {
        public BaseOrganizationProgramHttpService(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
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
