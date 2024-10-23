using SharedApplicationLayer.Contracts.Services;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Contracts.Services.Base.DataServices
{
    public interface IBaseOrganizationProgramDataService : IBaseDataService<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>
    {
    }
}
