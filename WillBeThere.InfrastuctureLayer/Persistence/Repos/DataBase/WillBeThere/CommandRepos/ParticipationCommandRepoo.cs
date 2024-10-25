using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class ParticipationCommandRepoo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseParticipationCommandRepo where TDbContext : DbContext
    {
        public ParticipationCommandRepoo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
