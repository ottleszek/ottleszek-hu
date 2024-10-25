using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseOrganizationCommandRepo where TDbContext : DbContext
    {
        public OrganizationCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
