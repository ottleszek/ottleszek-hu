using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationEditorCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IOrganizationEditorCommandRepo where TDbContext : DbContext
    {
        public OrganizationEditorCommandRepo(DbContext? dbContext) : base(dbContext)
        {
        }
    }
}
