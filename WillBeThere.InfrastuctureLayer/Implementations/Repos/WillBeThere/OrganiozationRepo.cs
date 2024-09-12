using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere
{
    public class OrganiozationRepo<TDbContext> : IncludedQueryRepo<TDbContext>
        where TDbContext : DbContext
    {
        public OrganiozationRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
