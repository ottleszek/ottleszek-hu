using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Context;

namespace WillBeThere.Backend.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyDatabaseData(this IApplicationBuilder app)
        {
            ApplyInMemoryDatabaseTestData(app);
            ApplyIdentityUserMigration(app);
        }

        private static void ApplyInMemoryDatabaseTestData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<WillBeThereInMemoryContext>();
                dbContext.Database.EnsureCreated();
            }
        }

        private static void ApplyIdentityUserMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<WillBeThereInMemoryContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
