using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;

namespace WillBeThere.HttpService.DataService
{
    public interface IOrganizationCategoryDataService : IBaseDataService<OrganizationCategory, OrganizationCategoryDto,OrganizationCategoryAssembler>
    {
    }
}
