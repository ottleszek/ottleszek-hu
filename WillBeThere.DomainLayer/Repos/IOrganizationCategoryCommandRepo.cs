using SharedDomainLayer.Repos.Commands;
using SharedDomainLayer.Responses;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Repos
{
    public interface IOrganizationCategoryCommandRepo : IBaseCommandRepo
    {
        Task<Response> Save(List<OrganizationCategory> organizationCategories);
    }
}
