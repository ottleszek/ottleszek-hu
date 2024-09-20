using MediatR;
using WillBeThere.ApplicationLayer.Contracts.Queries.OrganizationPrograms;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.InfrastuctureLayer.Handlers.OrganizationCategories
{
    public class GetOrganizationsCategoriesListHandler : IRequestHandler<GetPublicOrgranizationProgramListQuery, List<OrganizationCategory>>
    {
        public GetOrganizationsCategoriesListHandler()
        {
        }

        public Task<List<OrganizationCategory>> Handle(GetPublicOrgranizationProgramListQuery request, CancellationToken cancellationToken)
        {

        }
    }
}
