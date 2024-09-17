using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Services
{
    public interface IOrganizationCategoryService
    {
        IEnumerable<OrganizationCategory> GetOrganizationsCategories();
    }
}
