using WillBeThere.DomainLayer.Entites.ResultModels;

namespace WillBeThere.DomainLayer.Repos
{
    public interface IOrganizationProgramRepo
    {
        public Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationsProgramsAsync();
    }
}
