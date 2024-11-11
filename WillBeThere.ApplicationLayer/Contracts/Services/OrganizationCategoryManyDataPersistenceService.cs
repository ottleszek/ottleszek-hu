using Shared.DomainLayer.Responses;
using WillBeThere.ApplicationLayer.Services.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Contracts.Services
{
    public class OrganizationCategoryManyDataPersistenceService : IOrganizationCategoryManyDataPersistenceService
    {
        public Task<Response> UpdateMany(List<OrganizationCategory> entities)
        {

        }
    }
}
