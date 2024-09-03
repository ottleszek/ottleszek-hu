using WillBeThere.HttpService.MapperService;
using WillBeThere.Domain.Models.ResultModels;
using WillBeThere.Domain.Entites;
using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;

namespace WillBeThere.HttpService.DataService
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
