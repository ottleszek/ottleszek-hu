using WillBeThere.DomainLayer.Assemblers.ResultModels;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.MapperService
{
    public class BaseOrganizationProgramMapperService : BaseMapperService<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>, IBaseOrganizationProgramMapperService
    {
        private readonly IBaseOrganizationProgramHttpService? _organizationProgramHttpService;
        private readonly PublicOrganizationProgramAssembler? _publicOrganizationProgramAssembler;

        public BaseOrganizationProgramMapperService(
            IBaseOrganizationProgramHttpService? organizationProgramHttpService,
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
