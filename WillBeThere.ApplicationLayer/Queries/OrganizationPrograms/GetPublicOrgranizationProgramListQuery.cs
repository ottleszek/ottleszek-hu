using MediatR;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationPrograms
{
    public class GetPublicOrgranizationProgramListQuery : IRequest<List<PublicOrganizationProgramDto>> { }

}
