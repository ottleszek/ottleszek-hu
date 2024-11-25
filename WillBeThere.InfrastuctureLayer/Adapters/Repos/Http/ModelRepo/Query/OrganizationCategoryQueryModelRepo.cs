using WillBeThere.DomainLayer.Entites;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.ModelRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.MappreRepo;
using Shared.InfrastuctureLayer.Persistence.Repos.ModelRepo;

namespace WillBeThere.InfrastuctureLayer.Adapters.Repos.Http.ModelRepo.Query
{
    public class OrganizationCategoryQueryModelRepo : QueryModelRepo<OrganizationCategory, OrganizationCategoryDto>, IOrganizationCategoryQueryModelRepo
    {
        public OrganizationCategoryQueryModelRepo(IOrganizationCategoryQueryMapperRepo? mapperRepo) : base(mapperRepo)
        {
        }
    }
}
