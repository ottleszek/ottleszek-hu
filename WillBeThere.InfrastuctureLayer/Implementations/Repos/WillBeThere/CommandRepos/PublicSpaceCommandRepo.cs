using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class PublicSpaceCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBasePublicSpaceCommandRepo where TDbContext : DbContext
    {
        public PublicSpaceCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}

