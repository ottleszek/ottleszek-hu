using Shared.InfrastuctureLayer.Adapters.HttpRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;

namespace WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.Query
{
    public class OrganizationProgramQueryHttpRepo : QueryHttpRepo, IOrganizationProgramQueryHttpRepo
    {
        public OrganizationProgramQueryHttpRepo(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
