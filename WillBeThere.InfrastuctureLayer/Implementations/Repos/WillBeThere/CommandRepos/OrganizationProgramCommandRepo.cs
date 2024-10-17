using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationProgramCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationProgramCommandRepo where TDbContext : DbContext
    {
        public OrganizationProgramCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

    }
}
