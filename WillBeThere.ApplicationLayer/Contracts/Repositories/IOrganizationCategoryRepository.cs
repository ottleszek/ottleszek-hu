using SharedDomainLayer.Responses;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Contracts.Repositories
{
    public interface IOrganizationCategoryRepository
    {
        Task<Response> SaveOrganizationCategories(List<OrganizationCategory> organizationCategories);
    }
}
