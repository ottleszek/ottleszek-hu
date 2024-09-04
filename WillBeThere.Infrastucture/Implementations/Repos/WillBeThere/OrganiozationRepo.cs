using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Backend.Repos.WillBeThere
{
    public class OrganiozationRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IOrganizationRepo
        where TDbContext : DbContext
    {
        public OrganiozationRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
