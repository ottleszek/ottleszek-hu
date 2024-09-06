using WillBeThere.ApplicationLayer.Dtos;

namespace WillBeThere.ApplicationLayer.Services.HttpService
{
    public class OrganizationCategoryHttpService : BaseHttpService<OrganizationCategoryDto>, IOrganizationCategoryHttpService
    {
        public OrganizationCategoryHttpService(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
