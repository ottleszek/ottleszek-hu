using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class PublicSpaceDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IPublicSpaceCommandRepo where TDbContext : DbContext
    {
        public PublicSpaceDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}

