using WillBeThere.Domain.Models.ResultModels;

namespace WillBeThere.Backend.Services
{
    public interface IOrganizationProgramService
    {
        public IQueryable<PublicOrganizationProgram>? GetPublicOrganizationsPrograms();
    }
}
