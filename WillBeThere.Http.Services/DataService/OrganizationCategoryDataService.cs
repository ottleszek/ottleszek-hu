using WillBeThere.HttpService.MapperService;
using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.HttpService.DataService
{
    public class OrganizationCategoryDataService : BaseDataService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IOrganizationCategoryDataService
    {
        public OrganizationCategoryDataService(IOrganizationCategoryMapperService? mapperService) : base(mapperService)
        {
        }
    }
}
