using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationCommandRepo where TDbContext : DbContext
    {
        public OrganizationCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
