using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetFinal.Api.Domain;

namespace ProjetFinal.Api.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IConfiguration configuration;

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseSqlite(connectionString);

            base.OnConfiguring(optionsBuilder); 
        }

        public DbSet<Quote> Quotes { get; set; }

    }
}
