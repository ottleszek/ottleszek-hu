using SharedApplicationLayer.Contracts.Persistence;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Transformers.Converters;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http
{
    public class OrganizationCategoryDataPersistenceService : DataPersistenceService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryDomainDtoConverter>, IOrganizationCategoryDataPersistenceService
    {
        public OrganizationCategoryDataPersistenceService(OrganizationCategoryDomainDtoConverter? converter, IHttpPersistenceService httpPersistenceService) : base(converter, httpPersistenceService)
        {
        }
    }
}
