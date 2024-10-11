using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.MapperService
{
    public class BaseOrganizationCategoryMapperService : BaseMapperService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IBaseOrganizationCategoryMapperService
    {
        public BaseOrganizationCategoryMapperService(IBaseOrganizationCategoryHttpService? baseHttpService, OrganizationCategoryAssembler assambler) : base(baseHttpService, assambler)
        {
        }
    }
}
