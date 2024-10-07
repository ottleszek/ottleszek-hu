using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.Repositories;
using WillBeThere.ApplicationLayer.Contracts.Services.DataService;
using WillBeThere.ApplicationLayer.Contracts.Services.MapperService;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Repository.OrgaizationCategories
{
    public class OrganizationCategoryRepository : OrganizationCategoryDataService, IOrganizationCategoryRepository
    {
        private readonly IOrganizationCategoryMapperService? _organizationCategoryMapperService;

        public OrganizationCategoryRepository(IOrganizationCategoryMapperService? mapperService) : base(mapperService)
        {
            _organizationCategoryMapperService = mapperService;
        }

        public async Task<Response> SaveOrganizationCategories(List<OrganizationCategory> organizationCategories)
        {
            if (_organizationCategoryMapperService is not null)
            {
                foreach (var organizationCategory in organizationCategories)
                {
                    Response result = await _organizationCategoryMapperService.UpdateAsync(organizationCategory);
                }
            }
            return new Response();
        }
    }
}
