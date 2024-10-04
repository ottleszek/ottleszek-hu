using MediatR;
using WillBeThere.DomainLayer.Entites.ResultModels;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationPrograms
{
    public class GetPublicOrgranizationProgramListQuery : IRequest<List<PublicOrganizationProgram>> { }

}
