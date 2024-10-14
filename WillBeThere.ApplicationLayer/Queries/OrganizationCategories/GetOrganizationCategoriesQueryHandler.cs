using MediatR;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationCategories
{
    public class GetOrganizationCategoriesQueryHandler : IRequestHandler<GetOrganizationsCategoriesQuery, List<OrganizationCategoryDto>>
    {
        private readonly IBaseOrganizationCategoryDataService? _organizationCategoryDataService;
        private readonly OrganizationCategoryAssembler? _organizationCategoryAssembler;

        public GetOrganizationCategoriesQueryHandler(IBaseOrganizationCategoryDataService? organizationCategoryRepository, OrganizationCategoryAssembler? organizationCategoryAssembler)
        {
            _organizationCategoryDataService = organizationCategoryRepository;
            _organizationCategoryAssembler= organizationCategoryAssembler;
        }
        public async Task<List<OrganizationCategoryDto>> Handle(GetOrganizationsCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (_organizationCategoryDataService is not null && _organizationCategoryAssembler is not null)
            {
                List<OrganizationCategory> organizations = await _organizationCategoryDataService.SelectAsync();
                return organizations.Select(oc => _organizationCategoryAssembler.ToDto(oc)).ToList();

            }

            return new List<OrganizationCategoryDto>();
        }
    }
}
