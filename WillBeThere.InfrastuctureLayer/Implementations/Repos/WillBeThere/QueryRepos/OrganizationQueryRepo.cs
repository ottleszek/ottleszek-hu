using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos;


namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos
{
    public class OrganizationQueryRepo<TDbContext> : BaseCommandRepo<TDbContext>, IOrganizationProgramCommandRepo where TDbContext : DbContext
    {
    {
        public OrganizationQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

    }
}
