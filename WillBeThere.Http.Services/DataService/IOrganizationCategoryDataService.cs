using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;


namespace WillBeThere.HttpService.DataService
{
    public interface IOrganizationCategoryDataService : IBaseDataService<OrganizationCategory, OrganizationCategoryDto,OrganizationCategoryAssembler>
    {
    }
}
