using Shared.DomainLayer.Responses;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Repos
{
    public interface IOrganizationCategoryRepo
    {
        public Task<Response> SaveOrganizationCategories(List<OrganizationCategory> organizationCategories);
    }
}
