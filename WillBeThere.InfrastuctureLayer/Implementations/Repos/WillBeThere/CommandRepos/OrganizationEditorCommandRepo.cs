using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationEditorCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationEditorCommandRepo where TDbContext : DbContext
    {
        public OrganizationEditorCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
