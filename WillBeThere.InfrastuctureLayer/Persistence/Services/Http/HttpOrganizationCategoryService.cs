using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http
{
    public class HttpOrganizationCategoryService : HttpDataPersistenceService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IHttpOrganizationCategoryService
    {
        public HttpOrganizationCategoryService(IHttpClientFactory? httpClientFactory, OrganizationCategoryAssembler? assambler) : base(httpClientFactory, assambler)
        {
        }
    }
}
