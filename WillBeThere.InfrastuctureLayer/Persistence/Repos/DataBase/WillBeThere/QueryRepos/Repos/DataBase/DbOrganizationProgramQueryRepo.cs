using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Repos.Queries;
using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.Repos.DataBase
{
    public class DbOrganizationProgramQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>,  IOrganizationProgramQueryRepo where TDbContext : DbContext
    {
        public DbOrganizationProgramQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            return Enumerable.Empty<TEntity>().AsQueryable();
        }
    }
}
