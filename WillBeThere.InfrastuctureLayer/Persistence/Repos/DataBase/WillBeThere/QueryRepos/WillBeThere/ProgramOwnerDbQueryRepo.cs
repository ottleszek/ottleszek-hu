using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.WillBeThere;
using WillBeThere.InfrastuctureLayer.Context;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere
{
    public class ProgramOwnerDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IProgamOwnerQueryRepo where TDbContext : WillBeThereContext
    {
        public ProgramOwnerDbQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
