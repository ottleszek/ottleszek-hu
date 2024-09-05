using MediatR;
using WillBeThere.Domain.Models.ResultModels;

namespace WillBeThere.Application.Queries.OrganizationPrograms
{
    public class GetPublicOrgranizationProgramListQuery : IRequest<List<PublicOrganizationProgram>> { }

}
