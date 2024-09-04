using WillBeThere.Application.Assemblers;
using WillBeThere.Application.Dtos;
using WillBeThere.Domain.Entites;
using WillBeThere.Domain.Models.ResultModels;

namespace WillBeThere.Application.Services.MapperService
{
    public interface IOrganizationProgramMapperService : IBaseMapperService<OrganizationProgram, OrganizationProgramDto,OrganizationProgramAssembler>
    {
        Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}
