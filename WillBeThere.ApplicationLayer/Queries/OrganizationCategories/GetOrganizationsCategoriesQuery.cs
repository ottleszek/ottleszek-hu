using MediatR;
using WillBeThere.ApplicationLayer.Contracts.Dtos;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationCategories
{
    public class GetOrganizationsCategoriesQuery : IRequest<List<OrganizationCategoryDto>> { }

}
