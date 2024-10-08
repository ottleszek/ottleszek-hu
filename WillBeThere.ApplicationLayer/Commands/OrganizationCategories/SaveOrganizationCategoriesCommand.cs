using MediatR;
using SharedDomainLayer.Responses;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Commands.OrganizationCategories
{
    public class SaveOrganizationCategoriesCommand : IRequest<Response>
    {
        public List<OrganizationCategory> OrganizationCategories { get; set; }

        public SaveOrganizationCategoriesCommand(List<OrganizationCategory> organizationCategories)
        {
            OrganizationCategories = organizationCategories;
        }
    }
}
