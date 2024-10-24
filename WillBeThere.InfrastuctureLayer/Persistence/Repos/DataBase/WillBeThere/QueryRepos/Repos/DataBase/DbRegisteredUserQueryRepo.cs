using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.Repos.DataBase
{
    public class DbRegisteredUserQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IRegisteredUserQueryRepo
        where TDbContext : DbContext
    {
        public DbRegisteredUserQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
