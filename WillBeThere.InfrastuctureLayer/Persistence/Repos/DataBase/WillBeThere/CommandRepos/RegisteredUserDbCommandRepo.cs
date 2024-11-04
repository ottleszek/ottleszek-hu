using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class RegisteredUserDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseRegisteredUserCommandRepo where TDbContext : DbContext
    {
        public RegisteredUserDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
