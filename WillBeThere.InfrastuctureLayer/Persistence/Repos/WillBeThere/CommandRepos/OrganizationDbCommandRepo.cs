using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Persistence.Repos.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IOrganizationCommandRepo where TDbContext : DbContext
    {
        public OrganizationDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
