using WillBeThere.Shared.Dtos;
using WillBeThere.Shared.Dtos.ResultModels;

namespace WillBeThere.HttpService.HttpService
{
    public interface IOrganizationProgramHttpService : IBaseHttpService<OrganizationProgramDto>
    {
        Task<List<PublicOrganizationProgramDto>> GetAllPublicOrganizationProgramsAsync();
    }
}
