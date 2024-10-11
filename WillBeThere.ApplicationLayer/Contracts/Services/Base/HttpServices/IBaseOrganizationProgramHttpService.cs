using SharedApplicationLayer.Contracts.Services;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;

namespace WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices
{
    public interface IBaseOrganizationProgramHttpService : IBaseHttpService<OrganizationProgramDto>
    {
        Task<List<PublicOrganizationProgramDto>> GetAllPublicOrganizationProgramsAsync();
    }
}
