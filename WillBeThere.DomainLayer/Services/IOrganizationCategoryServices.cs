using SharedDomainLayer.Responses;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Services
{
    public interface IOrganizationCategoryServices
    {
        public Task<Response> SaveOrganizationCategories(List<OrganizationCategory> organizationCategories);
    }
}
