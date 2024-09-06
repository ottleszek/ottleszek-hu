using WillBeThere.DomainLayer.Entites.ResultModels;

namespace WillBeThere.InfrastuctureLayer.Implementations.Services
{
    public interface IOrganizationProgramService
    {
        public IQueryable<PublicOrganizationProgram>? GetPublicOrganizationsPrograms();
    }
}
