using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationProgramCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseCommandRepo, IOrganizationProgramCommandRepo where TDbContext : DbContext
    {
        public OrganizationProgramCommandRepo(DbContext? dbContext) : base(dbContext)
        {
        }

    }
}
