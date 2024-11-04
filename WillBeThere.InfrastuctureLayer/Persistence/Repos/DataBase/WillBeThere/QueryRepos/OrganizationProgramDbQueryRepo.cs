using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.InfrastuctureLayer.Context;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos
{
    public class OrganizationProgramDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationProgramQueryRepo where TDbContext : WillBeThereContext
    {
        public OrganizationProgramDbQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            return Enumerable.Empty<TEntity>().AsQueryable();
        }
    }
}
