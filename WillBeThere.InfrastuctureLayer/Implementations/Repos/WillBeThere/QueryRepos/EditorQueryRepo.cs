using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos
{
    public class EditorQueryRepo<TDbContext> : BaseCommandRepo<TDbContext>, IOrganizationProgramCommandRepo where TDbContext : DbContext
    {
        public EditorQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
