using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;
namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.DataService
{
    public class BaseOrganizationProgramDataService : BaseDataService<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>, IBaseOrganizationProgramDataService
    {
        private readonly IBaseOrganizationProgramMapperService? _organizationProgramMapperService;

        public BaseOrganizationProgramDataService(IBaseOrganizationProgramMapperService? organizationProgramMapperService) : base(organizationProgramMapperService)
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
