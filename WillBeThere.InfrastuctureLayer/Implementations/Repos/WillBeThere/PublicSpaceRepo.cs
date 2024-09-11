using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere
{
    public class PublicSpaceRepo<TDbContext> : INoCqrsRepo<TDbContext>, IPublicSpaceRepo
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
