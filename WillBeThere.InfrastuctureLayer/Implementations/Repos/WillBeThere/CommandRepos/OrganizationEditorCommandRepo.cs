using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.Base;
using WillBeThere.DomainLayer.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationEditorCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationEditorCommandRepo where TDbContext : DbContext
    {
        public OrganizationEditorCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
