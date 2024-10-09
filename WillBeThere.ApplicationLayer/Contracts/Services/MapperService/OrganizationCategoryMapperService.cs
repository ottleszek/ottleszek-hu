using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Services.HttpService;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using SharedApplicationLayer.Contracts.Services;

namespace WillBeThere.ApplicationLayer.Contracts.Services.MapperService
{
    public class OrganizationCategoryMapperService : BaseMapperService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IOrganizationCategoryMapperService
    {
        public OrganizationCategoryMapperService(IOrganizationCategoryHttpService? baseHttpService, OrganizationCategoryAssembler assambler) : base(baseHttpService, assambler)
        {
        }
    }
}
