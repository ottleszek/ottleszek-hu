using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base;

namespace WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.Query
{
    public class OrganizationCategoryQueryHttpRepo : QueryHttpRepo, IOrganizationCategoryQueryHttpRepo
    {
        public OrganizationCategoryQueryHttpRepo(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
