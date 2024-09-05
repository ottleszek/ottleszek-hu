using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Infrastucture.Implementations.Repos.WillBeThere
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
