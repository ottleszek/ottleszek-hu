using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.HttpService.MapperService
{
    public interface IOrganizationProgramMapperService : IBaseMapperService<OrganizationProgram, OrganizationProgramDto,OrganizationProgramAssembler>
    {
        Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}
