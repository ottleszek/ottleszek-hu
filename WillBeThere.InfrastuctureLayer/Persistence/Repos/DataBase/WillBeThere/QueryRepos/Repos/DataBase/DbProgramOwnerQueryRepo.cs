using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.Repos.DataBase
{
    public class DbProgramOwnerQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IProgamOwnerQueryRepo where TDbContext : DbContext
    {
        public DbProgramOwnerQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
