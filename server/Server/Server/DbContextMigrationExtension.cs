
using Microsoft.EntityFrameworkCore;

namespace Server
{
    public static class DbContextMigrationExtension
    {
        public static IHost MigrateDatabase<T>(this IHost host) where T : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                }
                catch (Exception)
                {
                    // log?
                    throw;
                }
            }

            return host;
        }
    }
}
