using MediatR;
using Microsoft.EntityFrameworkCore;
using WillBeThere.Application.Queries.OrganizationPrograms;
using WillBeThere.Domain.Models.ResultModels;
using WillBeThere.Infrastucture.Implementations.Services;

namespace WillBeThere.Infrastucture.Handlers.OrganizationPrograms
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
