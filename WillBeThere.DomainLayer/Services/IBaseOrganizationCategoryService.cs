using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Services
{
    public interface IBaseOrganizationCategoryService
    {
        Task<List<OrganizationCategory>> GetOrganizationsCategories();
    }
}
