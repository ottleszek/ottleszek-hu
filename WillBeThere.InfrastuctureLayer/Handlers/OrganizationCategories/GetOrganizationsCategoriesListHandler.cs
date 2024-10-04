using MediatR;
using WillBeThere.ApplicationLayer.Queries.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Services;

namespace WillBeThere.InfrastuctureLayer.Handlers.OrganizationCategories
{
    public class GetOrganizationsCategoriesListHandler : IRequestHandler<GetOrganizationsCategoriesQuery, List<OrganizationCategory>>
    {
        private readonly IBaseOrganizationCategoryService? _organizationCategoryService;
        public GetOrganizationsCategoriesListHandler(IBaseOrganizationCategoryService? organizationCategoryService)
        {
            _organizationCategoryService=organizationCategoryService;
        }

        public async Task<List<OrganizationCategory>> Handle(GetOrganizationsCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (_organizationCategoryService is not null)
            {
                return await _organizationCategoryService.GetOrganizationsCategories();
            }
            return new List<OrganizationCategory>();
        }
    }
}
