using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere
{
    public class OrganizationCategoryRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IOrganizationCategoryRepo
        where TDbContext : DbContext
    {
        public OrganizationCategoryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
