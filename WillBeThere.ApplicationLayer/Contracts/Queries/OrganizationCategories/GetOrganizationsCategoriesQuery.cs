using MediatR;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Contracts.Queries.OrganizationCategories
{
    public class GetOrganizationsCategoriesQuery : IRequest<List<OrganizationCategory>> { }

}
