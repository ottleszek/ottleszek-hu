using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase;
using WillBeThere.ApplicationLayer.Repos.QueryRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.Repos.DataBase
{
    public class ParticipationQueryRepoo<TDbContext> : IncludedQueryRepo<TDbContext>, IParticipationQueryRepo where TDbContext : DbContext
    {
        public ParticipationQueryRepoo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
