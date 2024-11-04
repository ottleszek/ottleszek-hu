using Shared.ApplicationLayer.Repos.Queries;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Repos.QueryRepo.MapperRepo
{
    public interface IOrganizationProgramQueryMapperRepo : IQueryMapperRepo<OrganizationProgram, OrganizationProgramDto>
    {
    }
}
