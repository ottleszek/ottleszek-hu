using Microsoft.EntityFrameworkCore;

namespace WillBeThere.InfrastuctureLayer.Context
{
    public class WillBeThereInMemoryContext : WillBeThereContext
    {
        public WillBeThereInMemoryContext(DbContextOptions<WillBeThereInMemoryContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
