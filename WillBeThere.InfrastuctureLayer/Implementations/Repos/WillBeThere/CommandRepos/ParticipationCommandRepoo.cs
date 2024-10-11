using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.Base;
using WillBeThere.DomainLayer.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class ParticipationCommandRepoo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseParticipationCommandRepo where TDbContext : DbContext
    {
        public ParticipationCommandRepoo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
