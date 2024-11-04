using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos
{
    public class OrganizationCategoryDbQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationCategoryQueryRepo
        where TDbContext : DbContext
    {
        public OrganizationCategoryDbQueryRepo(DbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
