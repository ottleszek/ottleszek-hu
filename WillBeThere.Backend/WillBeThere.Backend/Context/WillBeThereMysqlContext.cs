using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WillBeThere.Backend.Context
{
    public class WillBeThereMysqlContext : WillBeThereContext
    {
        public WillBeThereMysqlContext(DbContextOptions<WillBeThereMysqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
