using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Backend.Context
{
    public class WillBeThereMysqlContext : WillBeThereContext
    {
        public WillBeThereMysqlContext(DbContextOptions<WillBeThereMysqlContext> options) : base(options)
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
