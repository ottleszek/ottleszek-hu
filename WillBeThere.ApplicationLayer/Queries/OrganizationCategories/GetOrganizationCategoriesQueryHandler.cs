using MediatR;
using WillBeThere.ApplicationLayer.Contracts.Repositories;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationCategories
{
    public class GetOrganizationCategoriesQueryHandler : IRequestHandler<GetOrganizationsCategoriesQuery, List<OrganizationCategory>>
    {
        private readonly IOrganizationCategoryRepository _organizationCategoryRepository;
        public GetOrganizationCategoriesQueryHandler(IOrganizationCategoryRepository organizationCategoryRepository)
        {
            _organizationCategoryRepository = organizationCategoryRepository;
        }
        public async Task<List<OrganizationCategory>> Handle(GetOrganizationsCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (_organizationCategoryRepository is not null)
            {
                return await _organizationCategoryRepository.SelectAsync();
            }
            return new List<OrganizationCategory>();
        }
    }
}
