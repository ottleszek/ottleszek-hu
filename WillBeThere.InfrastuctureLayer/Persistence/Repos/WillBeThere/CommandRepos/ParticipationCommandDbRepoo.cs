using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Persistence.Repos.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class ParticipationCommandDbRepoo<TDbContext> : BaseCommandDbRepo<TDbContext>, IParticipationCommandRepo where TDbContext : DbContext
    {
        public ParticipationCommandDbRepoo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
