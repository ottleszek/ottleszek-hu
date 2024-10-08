using MediatR;
using WillBeThere.ApplicationLayer.Contracts.Repositories;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Handlers.OrganizationCategories
{
    public class GetOrganizationCategoriesCommandHandler : IRequestHandler<GetOrganizationCategoriesCommand, List<OrganizationCategory>>
    {
        private readonly IOrganizationCategoryRepository _organizationCategoryRepository;
        public GetOrganizationCategoriesCommandHandler(IOrganizationCategoryRepository organizationCategoryRepository)
        {
            _organizationCategoryRepository = organizationCategoryRepository;
        }
        public async Task<List<OrganizationCategory>> Handle(GetOrganizationCategoriesCommand request, CancellationToken cancellationToken)
        {
            if (_organizationCategoryRepository is not null)
            {
                return await _organizationCategoryRepository.SelectAsync();
            }
            return new List<OrganizationCategory>();
        }
    }
}
