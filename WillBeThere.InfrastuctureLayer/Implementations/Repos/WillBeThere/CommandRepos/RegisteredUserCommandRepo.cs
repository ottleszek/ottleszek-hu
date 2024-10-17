using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class RegisteredUserCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseRegisteredUserCommandRepo where TDbContext : DbContext
    {
        public RegisteredUserCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
