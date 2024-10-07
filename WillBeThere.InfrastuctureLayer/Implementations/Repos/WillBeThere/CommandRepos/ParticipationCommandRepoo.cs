using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class ParticipationCommandRepoo<TDbContext> : BaseCommandRepo<TDbContext>, IParticipationCommandRepo where TDbContext : DbContext
    {
        public ParticipationCommandRepoo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
