using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;
using WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.Http.HttpRepo.Query
{
    public class OrganizationProgramQueryHttpRepo : QueryHttpRepo, IOrganizationProgramQueryHttpRepo
    {
        public OrganizationProgramQueryHttpRepo(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
