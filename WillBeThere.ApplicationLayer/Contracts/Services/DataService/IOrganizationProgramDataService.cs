using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Entites.ResultModels;

namespace WillBeThere.ApplicationLayer.Contracts.Services.DataService
{
    public interface IOrganizationProgramDataService : IBaseDataService<OrganizationProgram, OrganizationProgramDto, OrganizationProgramAssembler>
    {
        public Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}
