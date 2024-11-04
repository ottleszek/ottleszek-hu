using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseOrganizationCommandRepo where TDbContext : DbContext
    {
        public OrganizationDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
