using WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.HttpService
{
    public class BaseOrganizationProgramHttpService : BaseHttpRepo, IBaseOrganizationProgramHttpService
    {
        public BaseOrganizationProgramHttpService(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
