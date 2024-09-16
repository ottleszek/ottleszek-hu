using MediatR;
using WillBeThere.DomainLayer.Entites.ResultModels;

namespace WillBeThere.ApplicationLayer.Contracts.Queries.OrganizationPrograms
{
    public class GetPublicOrgranizationProgramListQuery : IRequest<List<PublicOrganizationProgram>> { }

}
