using WillBeThere.HttpService.HttpService;
using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.HttpService.MapperService
{
    public class OrganizationCategoryMapperService : BaseMapperService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IOrganizationCategoryMapperService
    {
        public OrganizationCategoryMapperService(IOrganizationCategoryHttpService? baseHttpService, OrganizationCategoryAssembler assambler) : base(baseHttpService, assambler)
        {
        }
    }
}
