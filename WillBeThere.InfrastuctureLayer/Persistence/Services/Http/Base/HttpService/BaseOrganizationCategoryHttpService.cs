using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.HttpService
{
    public class BaseOrganizationCategoryHttpService : BaseHttpRepo, IBaseOrganizationCategoryHttpService
    {
        public BaseOrganizationCategoryHttpService(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
