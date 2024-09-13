using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos
{
    public class OrganizationProgramQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IBaseQueryRepo, IOrganizationProgramQueryRepo
        where TDbContext : DbContext
    {
        public OrganizationProgramQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            return Enumerable.Empty<TEntity>().AsQueryable();
        }
    }
}
