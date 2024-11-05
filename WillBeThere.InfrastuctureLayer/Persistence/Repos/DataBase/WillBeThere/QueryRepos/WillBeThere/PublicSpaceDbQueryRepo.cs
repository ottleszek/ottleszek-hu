using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.WillBeThere;
using WillBeThere.InfrastuctureLayer.Context;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere
{
    public class PublicSpaceDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IPublicSpaceQueryRepo where TDbContext : WillBeThereContext
    {
        public PublicSpaceDbQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
