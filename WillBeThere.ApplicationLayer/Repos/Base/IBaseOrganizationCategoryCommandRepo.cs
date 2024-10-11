using SharedApplicationLayer.Repos;
using SharedDomainLayer.Responses;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Repos.Base
{
    public interface IBaseOrganizationCategoryCommandRepo : IBaseCommandRepo
    {
        Task<Response> Save(List<OrganizationCategory> organizationCategories);
    }
}
