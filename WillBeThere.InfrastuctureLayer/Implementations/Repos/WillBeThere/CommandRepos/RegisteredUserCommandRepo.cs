using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class RegisteredUserCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IRegisteredUserCommandRepo where TDbContext : DbContext
    {
        public RegisteredUserCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
