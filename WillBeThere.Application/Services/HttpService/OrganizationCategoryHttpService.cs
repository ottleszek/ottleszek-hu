using WillBeThere.Application.Dtos;

namespace WillBeThere.Application.Services.HttpService
{
    public class OrganizationCategoryHttpService : BaseHttpService<OrganizationCategoryDto>, IOrganizationCategoryHttpService
    {
        public OrganizationCategoryHttpService(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
