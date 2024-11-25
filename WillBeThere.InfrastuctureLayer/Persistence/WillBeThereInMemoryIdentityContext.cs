using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Persistence.Context;

namespace WillBeThere.InfrastuctureLayer.Persistence
{
    public class WillBeThereInMemoryIdentityContext : IdentityContext<WillBeThereInMemoryIdentityContext>
    {
        public WillBeThereInMemoryIdentityContext(DbContextOptions<WillBeThereInMemoryIdentityContext> options) : base(options)
        {
        }
    }
}
