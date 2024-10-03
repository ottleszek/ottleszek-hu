using SharedDomainLayer.Responses;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Contracts.OrganizationCategories
{
    public interface IOrganizationCategory
    {
        Task<Response> Save(List<OrganizationCategory> organizationCategories);
    }
}
