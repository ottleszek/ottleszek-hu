using Shared.DomainLayer.Entities;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.ModelRepo;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.Http.Repos
{
    public class OrganizationCategoryQueryDataRepo : IOrganizationCategoryQueryRepo
    {
        private readonly IOrganizationCategoryQueryModelRepo _organizationCategoryGenericRepo;
            
        public OrganizationCategoryQueryDataRepo(IOrganizationCategoryQueryModelRepo organizationCategoryGenericRepo)
        {
            _organizationCategoryGenericRepo = organizationCategoryGenericRepo;
        }

        public async Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (typeof(TEntity) == typeof(OrganizationCategory))
            {
                List<OrganizationCategory> organizationCategories = await _organizationCategoryGenericRepo.GetAllAsync();
                return organizationCategories.ToList().Cast<TEntity>().ToList();
            }
            return new List<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (typeof(TEntity) == typeof(OrganizationCategory))
            {
                OrganizationCategory? organizationCategory = await _organizationCategoryGenericRepo.GetByIdAsync(id);
                return (TEntity?) (object?) organizationCategory;
            }
            return null;
        }

        public async Task<bool> IsExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (typeof(TEntity) == typeof(OrganizationCategory))
            {
                return await _organizationCategoryGenericRepo.IsExsistAsync(id);
            }
            return await Task.FromResult(false);
        }
    }
}
