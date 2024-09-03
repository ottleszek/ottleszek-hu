using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;

namespace WillBeThere.HttpService.MapperService
{
    public interface IOrganizationCategoryMapperService : IBaseMapperService<OrganizationCategory,OrganizationCategoryDto, OrganizationCategoryAssembler>
    {
    }
}
