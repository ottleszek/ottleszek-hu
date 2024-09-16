using MediatR;
using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Contracts.Queries.OrganizationPrograms;
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
            List<PublicOrganizationProgram> pop = new List<PublicOrganizationProgram>();
            if (_organizationProgramService is not null)
            {
                IQueryable<PublicOrganizationProgram>? publicProgramsQuery = _organizationProgramService.GetPublicOrganizationsPrograms();
                if (publicProgramsQuery is not null)
                {
                    pop = await publicProgramsQuery.ToListAsync(cancellationToken: cancellationToken);
                }
            }
            return pop;
        }
    }
}
