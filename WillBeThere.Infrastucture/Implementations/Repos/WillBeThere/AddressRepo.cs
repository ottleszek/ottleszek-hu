using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Infrastucture.Implementations.Repos.WillBeThere
{
    public class AddressRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IAddressRepo
        where TDbContext : DbContext
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
