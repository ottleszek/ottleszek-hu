using Microsoft.EntityFrameworkCore;
using WillBeThere.Infrastucture.Implementations.Repos.BaseRepos;

namespace WillBeThere.Infrastucture.Implementations.Repos.WillBeThere
{
    public class PublicSpaceRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IPublicSpaceRepo
        where TDbContext: DbContext
    {
        public PublicSpaceRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
