using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class ProgramOwnerDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseProgamOwnerCommandRepo where TDbContext : DbContext
    {
        public ProgramOwnerDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
