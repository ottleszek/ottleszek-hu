using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Persistence.Context;

namespace WillBeThere.InfrastuctureLayer.Persistence.Context
{
    public class WillBeThereMysqlIdentityContext : IdentityContext<WillBeThereMysqlIdentityContext>
    {
        public WillBeThereMysqlIdentityContext(DbContextOptions<WillBeThereMysqlIdentityContext> options) : base(options)
        {
        }
    }
}
