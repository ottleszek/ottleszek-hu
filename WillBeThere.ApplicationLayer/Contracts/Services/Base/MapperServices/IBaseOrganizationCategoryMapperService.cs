using SharedApplicationLayer.Contracts.Services;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices
{
    public interface IBaseOrganizationCategoryMapperService : IBaseMapperService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>
    {
    }
}
