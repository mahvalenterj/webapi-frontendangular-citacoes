using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Api.Persistence
{
    public static class PersistenceExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<AppDbContext>();
            context?.Database.Migrate();
        }
    }
}