using MediatR;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.InfrastuctureLayer.Handlers.OrganizationCategories
{
    public class GetOrganizationsCategoriesHandler : IRequestHandler<GetOrganizationsCategoriesHandler, List<OrganizationCategory>>
    {
        public GetOrganizationsCategoriesHandler()
        {
        }

        public Task<List<OrganizationCategory>> Handle(GetOrganizationsCategoriesHandler request, CancellationToken cancellationToken)
        {
        }
    }
}
