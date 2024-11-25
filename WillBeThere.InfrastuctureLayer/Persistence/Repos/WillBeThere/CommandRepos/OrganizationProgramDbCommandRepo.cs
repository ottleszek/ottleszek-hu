using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Persistence.Repos.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationProgramDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IOrganizationProgramCommandRepo where TDbContext : DbContext
    {
        public OrganizationProgramDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

    }
}
