using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class ProgramOwnerCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseProgamOwnerCommandRepo where TDbContext : DbContext
    {
        public ProgramOwnerCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
