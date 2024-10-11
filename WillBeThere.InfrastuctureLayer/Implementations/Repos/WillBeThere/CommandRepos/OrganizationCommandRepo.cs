using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.Base;
using WillBeThere.DomainLayer.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationCommandRepo where TDbContext : DbContext
    {
        public OrganizationCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
