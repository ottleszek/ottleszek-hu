using MediatR;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationCategories
{
    public class GetOrganizationsCategoriesQuery : IRequest<List<OrganizationCategory>> { }

}
