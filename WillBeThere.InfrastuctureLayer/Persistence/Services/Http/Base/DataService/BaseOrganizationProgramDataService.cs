using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http.Base.DataService
{
    public class BaseOrganizationProgramDataService : BaseDataRepo<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>, IBaseOrganizationProgramDataService
    {
        private readonly IBaseOrganizationProgramMapperService? _organizationProgramMapperService;

        public BaseOrganizationProgramDataService(IBaseOrganizationProgramMapperService? organizationProgramMapperService) : base(organizationProgramMapperService)
        {
            _organizationProgramMapperService = organizationProgramMapperService;
        }
    }
}
