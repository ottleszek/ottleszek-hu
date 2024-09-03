using WillBeThere.Domain.Dtos;
using WillBeThere.Domain.Dtos.ResultModels;

namespace WillBeThere.HttpService.HttpService
{
    public interface IOrganizationProgramHttpService : IBaseHttpService<OrganizationProgramDto>
    {
        Task<List<PublicOrganizationProgramDto>> GetAllPublicOrganizationProgramsAsync();
    }
}
