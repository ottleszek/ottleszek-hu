using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;

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
