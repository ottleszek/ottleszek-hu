using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.DataBase
{
    public class DbOrganizationCategoryServices : DbDataPersistenceService<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>
    {
        public DbOrganizationCategoryServices()
        {
        }
    }
}
