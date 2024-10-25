using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationEditorCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseOrganizationEditorCommandRepo where TDbContext : DbContext
    {
        public OrganizationEditorCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
