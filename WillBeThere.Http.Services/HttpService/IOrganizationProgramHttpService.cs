using WillBeThere.Application.Dtos;
using WillBeThere.Application.Dtos.ResultModels;

namespace WillBeThere.HttpService.HttpService
{
    public interface IOrganizationProgramHttpService : IBaseHttpService<OrganizationProgramDto>
    {
        Task<List<PublicOrganizationProgramDto>> GetAllPublicOrganizationProgramsAsync();
    }
}
