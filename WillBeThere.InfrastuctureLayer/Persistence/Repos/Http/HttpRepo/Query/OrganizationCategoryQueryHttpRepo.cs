using Shared.ApplicationLayer.Repos.Queries;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.Http.HttpRepo.Query
{
    public class OrganizationCategoryQueryHttpRepo : QueryHttpRepo, IOrganizationCategoryQueryHttpRepo
    {
        public OrganizationCategoryQueryHttpRepo(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
