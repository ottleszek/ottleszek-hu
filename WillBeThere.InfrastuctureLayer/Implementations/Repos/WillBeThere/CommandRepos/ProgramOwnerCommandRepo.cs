using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class ProgramOwnerCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IProgamOwnerCommandRepo where TDbContext : DbContext
    {
        public ProgramOwnerCommandRepo(DbContext? dbContext) : base(dbContext)
        {
        }
    }
}
