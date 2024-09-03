using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Backend.Repos.WillBeThere
{
    public class RegisteredUserRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IRegisteredUserRepo
        where TDbContext : DbContext
    {
        public RegisteredUserRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
