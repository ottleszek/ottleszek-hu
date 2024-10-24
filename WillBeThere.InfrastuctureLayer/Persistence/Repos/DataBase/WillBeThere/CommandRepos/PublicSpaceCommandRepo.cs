using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class PublicSpaceCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBasePublicSpaceCommandRepo where TDbContext : DbContext
    {
        public PublicSpaceCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}

