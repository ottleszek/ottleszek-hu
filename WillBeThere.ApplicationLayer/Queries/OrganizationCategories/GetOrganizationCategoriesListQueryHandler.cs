using MediatR;
using SharedApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Repos.Base;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationCategories
{
    public class GetOrganizationCategoriesListQueryHandler : IRequestHandler<GetOrganizationsCategoriesListQuery, List<OrganizationCategoryDto>>
    {
        private readonly IBaseOrganizationCategoryRepo? _organizationCategoryService;
        private readonly IDomainDtoConterter<OrganizationCategory, OrganizationCategoryDto>? _organizationCategoryDomainDtoConverter;

        public GetOrganizationCategoriesListQueryHandler(
            IBaseOrganizationCategoryRepo? organizationCategoryService,
            IDomainDtoConterter<OrganizationCategory, OrganizationCategoryDto>? organizationCategoryDomainDtoConverter
            )
        {
            _organizationCategoryService = organizationCategoryService;
            _organizationCategoryDomainDtoConverter= organizationCategoryDomainDtoConverter;
        }

        public async Task<List<OrganizationCategoryDto>> Handle(GetOrganizationsCategoriesListQuery request, CancellationToken cancellationToken)
        {
            if (_organizationCategoryService is not null && _organizationCategoryDomainDtoConverter is not null)
            {
                List<OrganizationCategory> categories = await _organizationCategoryService.GetOrganizationsCategories();
                return _organizationCategoryDomainDtoConverter.ToDto(categories);
            }
            return new List<OrganizationCategoryDto>();
        }
    }
}
