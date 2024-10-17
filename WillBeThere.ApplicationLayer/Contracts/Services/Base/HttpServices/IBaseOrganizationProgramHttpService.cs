using SharedApplicationLayer.Contracts.Services;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;

namespace WillBeThere.ApplicationLayer.Contracts.Services.Base.HttpServices
{
    public interface IBaseOrganizationProgramHttpService : IBaseHttpService
    {
        Task<List<PublicOrganizationProgramDto>> GetAllPublicOrganizationProgramsAsync();
    }
}
