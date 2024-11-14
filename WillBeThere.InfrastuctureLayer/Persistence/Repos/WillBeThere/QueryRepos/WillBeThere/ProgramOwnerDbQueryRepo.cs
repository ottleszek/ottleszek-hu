using Shared.InfrastuctureLayer.Persistence.Repos;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere.Backend;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere
{
    public class ProgramOwnerDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IProgamOwnerDbQueryRepo where TDbContext : WillBeThereContext
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
