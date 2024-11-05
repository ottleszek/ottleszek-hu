using MediatR;
using Shared.ApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.WillBeThere;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationCategories
{
    public class GetOrganizationCategoriesListQueryHandler : IRequestHandler<GetOrganizationsCategoriesListQuery, List<OrganizationCategoryDto>>
    {
        private readonly IOrganizationCategoryQueryRepo? _organizationCategoryService;
        private readonly IDomainDtoConterter<OrganizationCategory, OrganizationCategoryDto>? _organizationCategoryDomainDtoConverter;

        public GetOrganizationCategoriesListQueryHandler(
            IOrganizationCategoryQueryRepo? organizationCategoryService,
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
                List<OrganizationCategory> categories = await _organizationCategoryService.GetAllAsync<OrganizationCategory>();
                return _organizationCategoryDomainDtoConverter.ToDto(categories);
            }
            return new List<OrganizationCategoryDto>();
        }
    }
}
