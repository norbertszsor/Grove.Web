using Grove.Data;
using Microsoft.EntityFrameworkCore;

namespace Grove.Web.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<GroveDbContext>();

            dbContext.Database.Migrate();

            return app;
        }
    }
}
