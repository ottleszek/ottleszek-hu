using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Infrastucture.Implementations.Repos.WillBeThere
{
    public class ParticipationRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IParticipationRepo
        where TDbContext : DbContext
    {
        public ParticipationRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
