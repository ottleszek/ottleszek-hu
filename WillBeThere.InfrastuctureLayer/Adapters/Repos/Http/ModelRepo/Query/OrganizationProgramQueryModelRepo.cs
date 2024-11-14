using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.ModelRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MapperRepo;
using Shared.InfrastuctureLayer.Persistence.Repos.ModelRepo;

namespace WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.ModelRepo.Query
{
    public class OrganizationProgramQueryModelRepo : QueryModelRepo<OrganizationProgram, OrganizationProgramDto>, IOrganizationProgramQueryModelRepo
    {
        public OrganizationProgramQueryModelRepo(IOrganizationProgramQueryMapperRepo? mapperRepo) : base(mapperRepo)
        {
        }
    }
}
