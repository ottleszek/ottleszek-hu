using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.DomainLayer.Services.Base
{
    public interface IBaseOrganizationCategoryService
    {
        Task<List<OrganizationCategory>> GetOrganizationsCategories();
    }
}
