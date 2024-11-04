using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class AddressDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseAddressCommandRepo where TDbContext : DbContext
    {
        public AddressDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
