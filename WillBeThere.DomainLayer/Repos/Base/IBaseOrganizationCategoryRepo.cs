using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Repos.Base
{
    public interface IBaseOrganizationCategoryRepo
    {
        Task<List<OrganizationCategory>> GetOrganizationsCategories();
    }
}
