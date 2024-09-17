using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Entites.ResultModels;

namespace WillBeThere.ApplicationLayer.Contracts.Services.MapperService
{
    public interface IOrganizationProgramMapperService : IBaseMapperService<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>
    {
        Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}
