using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MappreRepo;
using Shared.ApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;
using Shared.InfrastuctureLayer.Persistence.Repos.MapperRepo;

namespace WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.MapperRepo.Query
{
    public class OrganizationCategoryQueryMapperRepo : QueryMapperRepo<OrganizationCategory, OrganizationCategoryDto>, IOrganizationCategoryQueryMapperRepo
    {
        public OrganizationCategoryQueryMapperRepo(IOrganizationCategoryQueryHttpRepo? baseHttpRepo, IAssembler<OrganizationCategory, OrganizationCategoryDto>? assambler) : base(baseHttpRepo, assambler)
        {
        }
    }
}
