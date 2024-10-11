using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.Base;
using WillBeThere.DomainLayer.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class RegisteredUserCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseRegisteredUserCommandRepo where TDbContext : DbContext
    {
        public RegisteredUserCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
