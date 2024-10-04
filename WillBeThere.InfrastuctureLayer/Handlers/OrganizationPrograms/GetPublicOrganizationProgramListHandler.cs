using MediatR;
using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Queries.OrganizationPrograms;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.InfrastuctureLayer.Implementations.Services;

namespace WillBeThere.InfrastuctureLayer.Handlers.OrganizationPrograms
{
    public class GetPublicOrganizationProgramListHandler : IRequestHandler<GetPublicOrgranizationProgramListQuery, List<PublicOrganizationProgram>>
    {
        private readonly IOrganizationProgramService _organizationProgramService;

        public GetPublicOrganizationProgramListHandler(IOrganizationProgramService organizationProgramService)
        {
            this._organizationProgramService = organizationProgramService;
        }
        public async Task<List<PublicOrganizationProgram>> Handle(GetPublicOrgranizationProgramListQuery request, CancellationToken cancellationToken)
        {
            if (_organizationProgramService is not null)
            {
                List<PublicOrganizationProgram>? pop = await _organizationProgramService.GetPublicOrganizationsPrograms();
                if (pop is not null)
                    return pop;
            }
            return new List<PublicOrganizationProgram>();
        }
    }
}
