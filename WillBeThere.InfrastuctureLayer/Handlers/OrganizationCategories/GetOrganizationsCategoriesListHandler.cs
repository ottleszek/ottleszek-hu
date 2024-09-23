using MediatR;
using WillBeThere.ApplicationLayer.Contracts.Queries.OrganizationPrograms;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Services;

namespace WillBeThere.InfrastuctureLayer.Handlers.OrganizationCategories
{
    public class GetOrganizationsCategoriesListHandler : IRequestHandler<GetPublicOrgranizationProgramListQuery, List<OrganizationCategory>>
    {
        private readonly IBaseOrganizationCategoryService _organizationCategoryService;
        public GetOrganizationsCateg(IBaseOrganizationCategoryService organizationCategoryService)
        {
            _organizationCategoryService=organizationCategoryService;
        }

        public Task<List<OrganizationCategory>> Handle(GetPublicOrgranizationProgramListQuery request, CancellationToken cancellationToken)
        {
         return _organizationCategoryService.GetOrganizationsCategories().ToList();
        }
    }
}
