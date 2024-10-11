using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class PublicSpaceCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBasePublicSpaceCommandRepo where TDbContext : DbContext
    {
        public PublicSpaceCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}

