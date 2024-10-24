using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class AddressCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseAddressCommandRepo where TDbContext : DbContext
    {
        public AddressCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
