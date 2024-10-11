using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Services.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;

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
            return await _organizationCategoryQueryRepo.SelectAll<OrganizationCategory>().ToListAsync();
            
        }
    }
}
