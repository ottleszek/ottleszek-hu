using Microsoft.EntityFrameworkCore;
using SharedApplicationLayer.Repos;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos
{
    public class OrganizationProgramQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IBaseQueryRepo, IOrganizationProgramQueryRepo where TDbContext : DbContext
    {
        public OrganizationProgramQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            return Enumerable.Empty<TEntity>().AsQueryable();
        }
    }
}
