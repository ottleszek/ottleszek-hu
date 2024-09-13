using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere
{
    public class AddressRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IAddressQueryRepo where TDbContext : DbContext
    {
        public AddressRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
