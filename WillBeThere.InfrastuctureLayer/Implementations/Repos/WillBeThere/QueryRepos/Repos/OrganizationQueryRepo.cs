using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos
{
    public class OrganizationQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationQueryRepo where TDbContext : DbContext
    {
        public OrganizationQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
