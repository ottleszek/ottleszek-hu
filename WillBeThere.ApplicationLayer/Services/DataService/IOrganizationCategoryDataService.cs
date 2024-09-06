using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.DomainLayer.Entites;


namespace WillBeThere.ApplicationLayer.Services.DataService
{
    public interface IOrganizationCategoryDataService : IBaseDataService<OrganizationCategory, OrganizationCategoryDto,OrganizationCategoryAssembler>
    {
    }
}
