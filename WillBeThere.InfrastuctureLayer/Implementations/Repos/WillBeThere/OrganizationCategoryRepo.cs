using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere
{
    public class OrganizationCategoryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationCategoryRepo
        where TDbContext : DbContext
    {
        public OrganizationCategoryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
