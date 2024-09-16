using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos
{
    public class OrganizationCategoryQueryRepo<TDbContext> : BaseQueryRepo<TDbContext>, IOrganizationCategoryQueryRepo
        where TDbContext : DbContext
    {
        public OrganizationCategoryQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
