using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Services.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Services
{
    public class BaseOrganizationCategoryServices : IBaseOrganizationCategoryService 
    {
        private IOrganizationCategoryQueryRepo? _organizationCategoryQueryRepo;

        public BaseOrganizationCategoryServices(IOrganizationCategoryQueryRepo? organizationCategoryQueryRepo)
        {
            _organizationCategoryQueryRepo = organizationCategoryQueryRepo;
        }

        public async Task<List<OrganizationCategory>>  GetOrganizationsCategories()
        {
            if (_organizationCategoryQueryRepo is null)
                return new List<OrganizationCategory>();
            return await _organizationCategoryQueryRepo.SelectAllAsync<OrganizationCategory>();
            
        }
    }
}
