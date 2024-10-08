using MediatR;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Handlers.OrganizationCategories
{
    public class GetOrganizationCategoriesCommand : IRequest<List<OrganizationCategory>>
    {
    }
}
