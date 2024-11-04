using Shared.ApplicationLayer.Repos.Queries;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Repos.QueryRepo.ModelRepo
{
    public interface IOrganizationCategoryQueryModelRepo : IQueryMapperRepo<OrganizationCategory,OrganizationCategoryDto>
    {
    }
}
