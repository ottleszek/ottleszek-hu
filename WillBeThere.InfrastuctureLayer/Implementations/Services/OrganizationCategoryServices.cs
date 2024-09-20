using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Services;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Services
{
    public class OrganizationCategoryServices : IOrganizationCategoryService 
    {
        private IWillBeThereWrapQueryUnitOfWork _unitOfWork;

        public OrganizationCategoryServices(IWillBeThereWrapQueryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrganizationCategory> GetOrganizationsCategories()
        {
            
        }
    }
}
