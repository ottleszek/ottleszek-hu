using WillBeThere.HttpService.MapperService;
using WillBeThere.Domain.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Application.Assemblers;

namespace WillBeThere.HttpService.DataService
{
    public class OrganizationCategoryDataService : BaseDataService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IOrganizationCategoryDataService
    {
        public OrganizationCategoryDataService(IOrganizationCategoryMapperService? mapperService) : base(mapperService)
        {
        }
    }
}
