using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Backend.Services
{
    public interface IOrganizationProgramService
    {
        public IQueryable<PublicOrganizationProgram>? GetPublicOrganizationsPrograms();
    }
}
