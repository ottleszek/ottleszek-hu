using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class ProgramOwnerCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseProgamOwnerCommandRepo where TDbContext : DbContext
    {
        public ProgramOwnerCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
