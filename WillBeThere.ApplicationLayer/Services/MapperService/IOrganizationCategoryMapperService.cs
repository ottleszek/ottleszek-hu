using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Services.MapperService
{
    public interface IOrganizationCategoryMapperService : IBaseMapperService<OrganizationCategory,OrganizationCategoryDto, OrganizationCategoryAssembler>
    {
    }
}
