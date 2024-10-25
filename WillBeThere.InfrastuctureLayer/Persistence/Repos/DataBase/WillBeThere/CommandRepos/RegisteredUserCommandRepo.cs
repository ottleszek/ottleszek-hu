using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class RegisteredUserCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseRegisteredUserCommandRepo where TDbContext : DbContext
    {
        public RegisteredUserCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
