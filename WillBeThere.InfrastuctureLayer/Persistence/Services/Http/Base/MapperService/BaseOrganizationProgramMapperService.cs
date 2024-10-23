using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices;
using WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.ApplicationLayer.Transformers.Assemblers.ResultModels;

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
    }
}
