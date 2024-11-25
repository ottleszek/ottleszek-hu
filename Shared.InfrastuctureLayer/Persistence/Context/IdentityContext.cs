using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Modules.Authentication.Models;

namespace Shared.InfrastuctureLayer.Persistence.Context
{
    public class IdentityContext<TDbContext> : IdentityDbContext<User> where TDbContext : DbContext
    {
        public IdentityContext(DbContextOptions<TDbContext> options) : base(options)
        {
        }
    }
}
