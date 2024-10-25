using WillBeThere.DomainLayer.Entites;

using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.MapperService
{
    public class BaseOrganizationCategoryMapperService : BaseMapperRepo<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IBaseOrganizationCategoryMapperService
    {
        public BaseOrganizationCategoryMapperService(IBaseOrganizationCategoryHttpService? baseHttpService, OrganizationCategoryAssembler assambler) : base(baseHttpService, assambler)
        {
        }
    }
}
