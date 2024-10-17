using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationCategoryCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationCategoryCommandRepo where TDbContext : DbContext
    {
        public OrganizationCategoryCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
