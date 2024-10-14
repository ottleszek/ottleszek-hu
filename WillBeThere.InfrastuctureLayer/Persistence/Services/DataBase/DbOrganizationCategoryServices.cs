using WillBeThere.ApplicationLayer.Assemblers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
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
