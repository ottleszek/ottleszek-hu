using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.InfrastuctureLayer.Context;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos
{
    public class OrganizationCategoryDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationCategoryQueryRepo where TDbContext : WillBeThereContext
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
