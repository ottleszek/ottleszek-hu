using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationDbCategoryCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseOrganizationCategoryCommandRepo where TDbContext : DbContext
    {
        public OrganizationDbCategoryCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
