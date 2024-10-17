using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class ParticipationCommandRepoo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseParticipationCommandRepo where TDbContext : DbContext
    {
        public ParticipationCommandRepoo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
