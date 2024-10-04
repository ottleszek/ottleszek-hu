using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Services.DataService;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Contracts.Repositories
{
    public interface IOrganizationCategoryRepository : IBaseDataService<OrganizationCategory,OrganizationCategoryDto,OrganizationCategoryAssembler>
    {
        Task<Response> SaveOrganizationCategories(List<OrganizationCategory> organizationCategories);
    }
}
