using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.HttpService.MapperService
{
    public interface IOrganizationCategoryMapperService : IBaseMapperService<OrganizationCategory,OrganizationCategoryDto, OrganizationCategoryAssembler>
    {
    }
}
