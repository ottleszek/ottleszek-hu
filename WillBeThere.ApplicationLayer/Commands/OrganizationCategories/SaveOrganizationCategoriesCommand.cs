using MediatR;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;

namespace WillBeThere.ApplicationLayer.Commands.OrganizationCategories
{
    public class SaveOrganizationCategoriesCommand : IRequest<Response>
    {
        public List<OrganizationCategoryDto> OrganizationCategories { get; set; }

        public SaveOrganizationCategoriesCommand(List<OrganizationCategoryDto> organizationCategories)
        {
            OrganizationCategories = organizationCategories;
        }
    }
}
