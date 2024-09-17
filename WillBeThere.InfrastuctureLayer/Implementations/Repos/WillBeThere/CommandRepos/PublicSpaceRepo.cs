using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class PublicSpaceRepo<TDbContext> : BaseCommandRepo<TDbContext>, IPublicSpaceCommandRepo where TDbContext : DbContext
    {
        public PublicSpaceRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}

