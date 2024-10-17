using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos
{
    public class ProgramOwnerQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IProgamOwnerQueryRepo where TDbContext : DbContext
    {
        public ProgramOwnerQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
