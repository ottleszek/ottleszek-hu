using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.Repositories;
using WillBeThere.ApplicationLayer.Contracts.Services.DataService;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Repository.OrgaizationCategories
{
    public class OrganizationCategoryRepository : IOrganizationCategoryRepository
    {
        private readonly IOrganizationCategoryDataService? _organizationCategoryDataService;
        public OrganizationCategoryRepository(IOrganizationCategoryDataService? organizationCategoryDataService)
        {
            _organizationCategoryDataService = organizationCategoryDataService;
        }

        public async Task<Response> SaveOrganizationCategories(List<OrganizationCategory> organizationCategories)
        {
            if (_organizationCategoryDataService is not null)
            {
                foreach (var organizationCategory in organizationCategories)
                {
                    Response result = await _organizationCategoryDataService.UpdateAsync(organizationCategory);
                }
            }
            return new Response();
        }
    }
}
