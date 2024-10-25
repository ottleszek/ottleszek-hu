namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.HttpService
{
    public class BaseOrganizationCategoryHttpService : QueryHttpRepo, IBaseOrganizationCategoryHttpService
    {
        public BaseOrganizationCategoryHttpService(IHttpClientFactory? httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}
