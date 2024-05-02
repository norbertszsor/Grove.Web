using Grove.Data;
using Grove.Data.Models;
using Grove.Logic.Helpers;
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

        public static WebApplication ApplySeed(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<GroveDbContext>();

            var root = scope.ServiceProvider.GetRequiredService<IConfiguration>()
                .GetSection("RootUser")
                .Get<UserEm>();

            if (dbContext.Users.Any() || root == null)
            {
                return app;
            } 

            dbContext.Users.Add(new UserEm()
            {
                Email = root.Email,
                UserType = root.UserType,
                Password = CryptHelper.HashString(root.Password)
            });

            dbContext.SaveChanges();

            return app;
        }
    }
}
