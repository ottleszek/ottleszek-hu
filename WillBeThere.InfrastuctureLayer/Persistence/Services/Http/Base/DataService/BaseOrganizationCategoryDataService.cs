using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.DataService
{
    public class BaseOrganizationCategoryDataService : BaseDataService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>, IBaseOrganizationCategoryDataService
    {
        public BaseOrganizationCategoryDataService(IBaseOrganizationCategoryMapperService? mapperService) : base(mapperService)
        {
        }
    }
}
