using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class AddressCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IAddressCommandRepo where TDbContext : DbContext
    {
        public AddressCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
