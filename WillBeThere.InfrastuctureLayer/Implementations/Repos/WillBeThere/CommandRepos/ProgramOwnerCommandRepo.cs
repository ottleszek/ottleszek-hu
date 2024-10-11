using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class ProgramOwnerCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseProgamOwnerCommandRepo where TDbContext : DbContext
    {
        public ProgramOwnerCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
