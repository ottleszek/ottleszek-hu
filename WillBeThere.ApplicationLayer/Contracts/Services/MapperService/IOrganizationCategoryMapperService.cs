using SharedApplicationLayer.Contracts.Services;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Contracts.Services.MapperService
{
    public interface IOrganizationCategoryMapperService : IBaseMapperService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>
    {
    }
}
