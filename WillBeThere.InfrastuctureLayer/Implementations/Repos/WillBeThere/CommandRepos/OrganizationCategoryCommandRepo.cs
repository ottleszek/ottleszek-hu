using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Repos.Base;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationCategoryCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationCategoryCommandRepo where TDbContext : DbContext
    {
        public OrganizationCategoryCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
