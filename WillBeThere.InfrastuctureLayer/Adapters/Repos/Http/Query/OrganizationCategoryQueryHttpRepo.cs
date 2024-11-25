using Shared.InfrastuctureLayer.Adapters.HttpRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;

namespace WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.Query
{
    public class OrganizationCategoryQueryHttpRepo : QueryHttpRepo, IOrganizationCategoryQueryHttpRepo
    {
        public OrganizationCategoryQueryHttpRepo(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
