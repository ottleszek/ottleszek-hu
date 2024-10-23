using MediatR;
using System.Diagnostics;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.ApplicationLayer.Extensions.ModelExtensions;
using WillBeThere.ApplicationLayer.Queries.OrganizationPrograms;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.DomainLayer.Repos;

namespace WillBeThere.InfrastuctureLayer.Handlers.OrganizationPrograms
{
    public class GetPublicOrganizationProgramListHandler : IRequestHandler<GetPublicOrgranizationProgramListQuery, List<PublicOrganizationProgramDto>>
    {
        private readonly IOrganizationProgramRepo _organizationProgramRepo;

        public GetPublicOrganizationProgramListHandler(IOrganizationProgramRepo organizationProgramService)
        {
            this._organizationProgramRepo = organizationProgramService;
        }
        public async Task<List<PublicOrganizationProgramDto>> Handle(GetPublicOrgranizationProgramListQuery request, CancellationToken cancellationToken)
        {
            if (_organizationProgramRepo is not null)
            {
                try
                {
                    List<PublicOrganizationProgram>? pop = await _organizationProgramRepo.GetAllPublicOrganizationsProgramsAsync();
                    if (pop is not null)
                        return pop.Select(pop => pop.ToDto()).ToList();
                }
                catch (ArgumentNullException ex)
                {
                    Debug.WriteLine(ex);
                }
                catch (Exception ex) 
                { 
                    Debug.WriteLine(ex);
                }
            }
            return new List<PublicOrganizationProgramDto>();
        }
    }
}
