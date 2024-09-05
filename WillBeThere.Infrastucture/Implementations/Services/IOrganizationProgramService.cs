using WillBeThere.Domain.Models.ResultModels;

namespace WillBeThere.Infrastucture.Implementations.Services
{
    public interface IOrganizationProgramService
    {
        public IQueryable<PublicOrganizationProgram>? GetPublicOrganizationsPrograms();
    }
}
