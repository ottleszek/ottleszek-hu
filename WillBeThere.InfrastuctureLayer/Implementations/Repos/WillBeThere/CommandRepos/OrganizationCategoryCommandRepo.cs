using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationCategoryCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IOrganizationCategoryCommandRepo where TDbContext : DbContext
    {
        public OrganizationCategoryCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
