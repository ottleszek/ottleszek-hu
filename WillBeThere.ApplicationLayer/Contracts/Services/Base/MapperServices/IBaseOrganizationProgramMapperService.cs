using SharedApplicationLayer.Contracts.Services;
using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Entites.ResultModels;

namespace WillBeThere.ApplicationLayer.Contracts.Services.Base.MapperServices
{
    public interface IBaseOrganizationProgramMapperService : IBaseMapperService<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>
    {
        Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}
