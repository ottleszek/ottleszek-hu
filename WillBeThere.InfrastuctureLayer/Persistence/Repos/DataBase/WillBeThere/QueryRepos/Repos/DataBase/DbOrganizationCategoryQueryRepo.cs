using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.Repos.DataBase
{
    public class DbOrganizationCategoryQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationCategoryQueryRepo
        where TDbContext : DbContext
    {
        public DbOrganizationCategoryQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
