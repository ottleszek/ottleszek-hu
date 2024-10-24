using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationProgramCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationProgramCommandRepo where TDbContext : DbContext
    {
        public OrganizationProgramCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

    }
}
