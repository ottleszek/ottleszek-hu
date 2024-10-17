using MediatR;
using SharedApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Queries.OrganizationCategories;
using WillBeThere.ApplicationLayer.Transformers.Converters;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Services.Base;

namespace WillBeThere.InfrastuctureLayer.Handlers.OrganizationCategories
{
    public class GetOrganizationCategoriesListHandler : IRequestHandler<GetOrganizationsCategoriesQuery, List<OrganizationCategoryDto>>
    {
        private readonly IBaseOrganizationCategoryService? _organizationCategoryService;
        private readonly IDomainDtoConterter<OrganizationCategory, OrganizationCategoryDto>? _organizationCategoryDomainDtoConverter;

        public GetOrganizationCategoriesListHandler(
            IBaseOrganizationCategoryService? organizationCategoryService,
            IDomainDtoConterter<OrganizationCategory, OrganizationCategoryDto>? organizationCategoryDomainDtoConverter
            )
        {
            _organizationCategoryService = organizationCategoryService;
            _organizationCategoryDomainDtoConverter= organizationCategoryDomainDtoConverter;
        }

        public async Task<List<OrganizationCategoryDto>> Handle(GetOrganizationsCategoriesQuery request, CancellationToken cancellationToken)
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
