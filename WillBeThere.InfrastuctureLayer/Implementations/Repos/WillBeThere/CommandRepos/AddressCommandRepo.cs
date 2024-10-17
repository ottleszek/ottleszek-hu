using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class AddressCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseAddressCommandRepo where TDbContext : DbContext
    {
        public AddressCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
