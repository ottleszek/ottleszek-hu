using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MappreRepo;
using Shared.InfrastuctureLayer.Repos.MapperRepo;
using Shared.ApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.HttpRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.Http.MapperRepo.Query
{
    public class OrganizationCategoryQueryMapperRepo : QueryMapperRepo<OrganizationCategory, OrganizationCategoryDto>, IOrganizationCategoryQueryMapperRepo
    {
        public OrganizationCategoryQueryMapperRepo(IOrganizationCategoryQueryHttpRepo? baseHttpRepo, IAssembler<OrganizationCategory, OrganizationCategoryDto>? assambler) : base(baseHttpRepo, assambler)
        {
        }
    }
}
