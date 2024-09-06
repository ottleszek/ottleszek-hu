using WillBeThere.DomainLayer.Assemblers.ResultModels;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.ApplicationLayer.Dtos.ResultModels;
using WillBeThere.ApplicationLayer.Services.HttpService;

namespace WillBeThere.ApplicationLayer.Services.MapperService
{
    public class OrganizationProgramMapperService : BaseMapperService<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>, IOrganizationProgramMapperService
    {
        private readonly IOrganizationProgramHttpService? _organizationProgramHttpService;
        private readonly PublicOrganizationProgramAssembler? _publicOrganizationProgramAssembler;

        public OrganizationProgramMapperService(
            IOrganizationProgramHttpService?organizationProgramHttpService, 
            OrganizationProgramAssembler? assambler,
            PublicOrganizationProgramAssembler? publicOrganizationProgramAssembler) : 
            base(organizationProgramHttpService, assambler)
        {
            if (organizationProgramHttpService is not null && publicOrganizationProgramAssembler is not null)
            {
                _organizationProgramHttpService = organizationProgramHttpService;
                _publicOrganizationProgramAssembler = publicOrganizationProgramAssembler;
            }
        }

        public async Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync()
        {
            if (_organizationProgramHttpService is null || _publicOrganizationProgramAssembler is null)
                return new List<PublicOrganizationProgram>();
            else
            {
                List<PublicOrganizationProgramDto> resultDto = await _organizationProgramHttpService.GetAllPublicOrganizationProgramsAsync();
                return resultDto.Select(entityDto => _publicOrganizationProgramAssembler.ToModel(entityDto)).ToList();
            }
        }
    }
}
