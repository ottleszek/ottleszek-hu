using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere.Backend;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere
{
    public class AddressDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IAddressDbQueryRepo where TDbContext : WillBeThereContext
    {
        public AddressDbQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
