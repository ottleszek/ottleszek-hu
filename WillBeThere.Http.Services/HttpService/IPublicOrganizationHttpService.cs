using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.HttpService.HttpService
{
    public interface IPublicOrganizationHttpService
    {
        Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationProgramsAsync();
    }
}
