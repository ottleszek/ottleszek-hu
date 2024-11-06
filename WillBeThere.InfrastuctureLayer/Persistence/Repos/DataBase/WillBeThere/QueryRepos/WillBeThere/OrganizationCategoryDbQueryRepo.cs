using Shared.ApplicationLayer.Repos;
using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere.Backend;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere
{
    public class OrganizationCategoryDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationCategoryDbQueryRepo, IIncludedQueryRepo where TDbContext : WillBeThereContext
    {
        public OrganizationCategoryDbQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
