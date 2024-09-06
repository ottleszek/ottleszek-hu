using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Entites.ResultModels;

namespace WillBeThere.ApplicationLayer.Services.MapperService
{
    public interface IOrganizationProgramMapperService : IBaseMapperService<OrganizationProgram, OrganizationProgramDto,OrganizationProgramAssembler>
    {
        Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}
