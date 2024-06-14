using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Backend.Repos.WillBeThere
{
    public class OrganizationProgramRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IOrganizationProgramRepo
        where TDbContext : DbContext
    {
        public OrganizationProgramRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            return Enumerable.Empty<TEntity>().AsQueryable();
        }
    }
}
