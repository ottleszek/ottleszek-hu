using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationEditorDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IOrganizationEditorCommandRepo where TDbContext : DbContext
    {
        public OrganizationEditorDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
