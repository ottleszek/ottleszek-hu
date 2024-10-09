using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Services.MapperService;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using SharedApplicationLayer.Contracts.Services;

namespace WillBeThere.ApplicationLayer.Contracts.Services.DataService
{
    public class OrganizationCategoryDataService : BaseDataService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IOrganizationCategoryDataService
    {
        public OrganizationCategoryDataService(IOrganizationCategoryMapperService? mapperService) : base(mapperService)
        {
        }
    }
}
