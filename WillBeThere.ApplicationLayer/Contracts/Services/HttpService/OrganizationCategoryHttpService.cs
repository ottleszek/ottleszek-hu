using WillBeThere.ApplicationLayer.Contracts.Dtos;

namespace WillBeThere.ApplicationLayer.Contracts.Services.HttpService
{
    public class OrganizationCategoryHttpService : BaseHttpService<OrganizationCategoryDto>, IOrganizationCategoryHttpService
    {
        public OrganizationCategoryHttpService(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
