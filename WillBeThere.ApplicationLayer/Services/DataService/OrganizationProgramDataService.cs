using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.ApplicationLayer.Services.MapperService;

namespace WillBeThere.ApplicationLayer.Services.DataService
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
