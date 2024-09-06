using Microsoft.EntityFrameworkCore;
using WillBeThere.Infrastucture.Implementations.Repos.BaseRepos;

namespace WillBeThere.Infrastucture.Implementations.Repos.WillBeThere
{
    public class OrganizationAdminUserRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IOrganizationAdminUserRepo
        where TDbContext : DbContext
    {
        public OrganizationAdminUserRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
