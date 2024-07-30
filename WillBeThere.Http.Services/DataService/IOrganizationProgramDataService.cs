using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Models;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.HttpService.DataService
{
    public interface IOrganizationProgramDataService : IBaseDataService<OrganizationProgram,OrganizationProgramDto,OrganizationProgramAssembler>
    {
        public Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}
