using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere.Backend;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere
{
    public class RegisteredUserDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IRegisteredUserDbQueryRepo where TDbContext : WillBeThereContext
    {
        public RegisteredUserDbQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
