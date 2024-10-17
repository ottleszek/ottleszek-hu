using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos
{
    public class AddressQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IAddressQueryRepo where TDbContext : DbContext
    {
        public AddressQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
