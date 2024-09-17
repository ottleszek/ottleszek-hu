using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IOrganizationProgramCommandRepo where TDbContext : DbContext
    {
        public OrganizationCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
