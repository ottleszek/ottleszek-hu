using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo.WillBeThere;
using WillBeThere.InfrastuctureLayer.Context;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WillBeThere
{
    public class AddressDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IAddressQueryRepo where TDbContext : WillBeThereContext
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
