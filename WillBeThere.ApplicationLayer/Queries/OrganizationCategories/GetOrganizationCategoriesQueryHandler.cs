using MediatR;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationCategories
{
    public class GetOrganizationCategoriesQueryHandler : IRequestHandler<GetOrganizationsCategoriesQuery, List<OrganizationCategory>>
    {
        private readonly IBaseOrganizationCategoryDataService _organizationCategoryDataService;
        public GetOrganizationCategoriesQueryHandler(IBaseOrganizationCategoryDataService organizationCategoryRepository)
        {
            _organizationCategoryDataService = organizationCategoryRepository;
        }
        public async Task<List<OrganizationCategory>> Handle(GetOrganizationsCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (_organizationCategoryDataService is not null)
            {
                return await _organizationCategoryDataService.SelectAsync();
            }
            return new List<OrganizationCategory>();
        }
    }
}
