using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.Base;
using WillBeThere.DomainLayer.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationProgramCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseOrganizationProgramCommandRepo where TDbContext : DbContext
    {
        public OrganizationProgramCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

    }
}
