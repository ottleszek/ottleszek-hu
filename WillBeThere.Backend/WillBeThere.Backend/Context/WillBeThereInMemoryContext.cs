using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Backend.Context
{
    public class WillBeThereInMemoryContext : WillBeThereContext
    {
        public WillBeThereInMemoryContext(DbContextOptions options) : base(options)
        {
        }
    }
}
