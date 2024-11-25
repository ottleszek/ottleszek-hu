using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Persistence.Repos.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class AddressDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IAddressCommandRepo where TDbContext : DbContext
    {
        public AddressDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
