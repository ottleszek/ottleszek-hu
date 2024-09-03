using WillBeThere.HttpService.HttpService;
using WillBeThere.Domain.Entites;
using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;

namespace WillBeThere.HttpService.MapperService
{
    public class OrganizationCategoryMapperService : BaseMapperService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IOrganizationCategoryMapperService
    {
        public OrganizationCategoryMapperService(IOrganizationCategoryHttpService? baseHttpService, OrganizationCategoryAssembler assambler) : base(baseHttpService, assambler)
        {
        }
    }
}
