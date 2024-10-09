using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Services.MapperService;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using SharedApplicationLayer.Contracts.Services;

namespace WillBeThere.ApplicationLayer.Contracts.Services.DataService
{
    public class OrganizationProgramDataService : BaseDataService<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>, IOrganizationProgramDataService
    {
        private readonly IOrganizationProgramMapperService? _organizationProgramMapperService;

        public OrganizationProgramDataService(IOrganizationProgramMapperService? organizationProgramMapperService) : base(organizationProgramMapperService)
        {
            _organizationProgramMapperService = organizationProgramMapperService;
        }

        public async Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync()
        {
            if (_organizationProgramMapperService is not null)
                return await _organizationProgramMapperService.GetAllPublicOrganizationProgramsAsync();
            else
                return new List<PublicOrganizationProgram>();
        }
    }
}
