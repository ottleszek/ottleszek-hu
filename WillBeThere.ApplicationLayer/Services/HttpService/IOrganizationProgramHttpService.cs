using WillBeThere.ApplicationLayer.Dtos;
using WillBeThere.ApplicationLayer.Dtos.ResultModels;

namespace WillBeThere.ApplicationLayer.Services.HttpService
{
    public interface IOrganizationProgramHttpService : IBaseHttpService<OrganizationProgramDto>
    {
        Task<List<PublicOrganizationProgramDto>> GetAllPublicOrganizationProgramsAsync();
    }
}
