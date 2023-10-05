using Microsoft.EntityFrameworkCore;
using ProjetFinal.Api.Domain;

namespace ProjetFinal.Api.Persistence
{
    public interface IAppDbContext
    {
        DbSet<Quote> Quotes { get; set; }

        int SaveChanges();
    }
}