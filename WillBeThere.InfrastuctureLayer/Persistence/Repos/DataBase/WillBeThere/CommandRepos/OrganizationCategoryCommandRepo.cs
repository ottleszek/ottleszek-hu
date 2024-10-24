using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationCategoryCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationCategoryCommandRepo where TDbContext : DbContext
    {
        public OrganizationCategoryCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
