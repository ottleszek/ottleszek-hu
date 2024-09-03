using WillBeThere.HttpService.MapperService;
using WillBeThere.Domain.Entites;
using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;

namespace WillBeThere.HttpService.DataService
{
    public class OrganizationCategoryDataService : BaseDataService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IOrganizationCategoryDataService
    {
        public OrganizationCategoryDataService(IOrganizationCategoryMapperService? mapperService) : base(mapperService)
        {
        }
    }
}
