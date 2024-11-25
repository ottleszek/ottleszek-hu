using Shared.InfrastuctureLayer.Persistence.Repos;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere.Backend;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere
{
    public class OrganizationDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationDbQueryRepo where TDbContext : WillBeThereContext
    {
        public OrganizationDbQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
