using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos
{
    public class RegisteredUserRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IRegisteredUserRepo
        where TDbContext : DbContext
    {
        public RegisteredUserRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
