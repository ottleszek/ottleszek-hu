using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Contracts.Dtos;
using Shared.InfrastuctureLayer.Repos.MapperRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MapperRepo;
using Shared.ApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;

namespace WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.MapperRepo.Query
{
    public class OrganizationProgramQueryMapperRepo : QueryMapperRepo<OrganizationProgram, OrganizationProgramDto>, IOrganizationProgramQueryMapperRepo
    {
        public OrganizationProgramQueryMapperRepo(IOrganizationCategoryQueryHttpRepo? baseHttpRepo, IAssembler<OrganizationProgram, OrganizationProgramDto>? assambler) : base(baseHttpRepo, assambler)
        {
        }
    }
}
