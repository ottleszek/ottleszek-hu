using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class PublicSpaceCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IPublicSpaceCommandRepo where TDbContext : DbContext
    {
        public PublicSpaceCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}

