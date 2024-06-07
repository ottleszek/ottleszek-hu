using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Backend.Context
{
    public class WillBeThereInMemoryContext : WillBeThereContext
    {
        public WillBeThereInMemoryContext(DbContextOptions<WillBeThereInMemoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
