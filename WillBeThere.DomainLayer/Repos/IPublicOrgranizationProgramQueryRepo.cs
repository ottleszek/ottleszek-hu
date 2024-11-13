using WillBeThere.DomainLayer.Entites.ResultModels;

namespace WillBeThere.DomainLayer.Repos
{
    public interface IPublicOrgranizationProgramQueryRepo
    {
        public Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationsProgramsAsync();
    }
}
