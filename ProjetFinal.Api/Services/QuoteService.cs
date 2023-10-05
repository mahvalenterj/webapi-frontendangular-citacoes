using ProjetFinal.Api.Domain;
using ProjetFinal.Api.Models;
using ProjetFinal.Api.Persistence;

namespace ProjetFinal.Api.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IAppDbContext dbContext;

        public QuoteService(IAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Quote> GetAll()
        {
            return dbContext.Quotes;
        }

        public Quote GetById(int id)
        {
            return dbContext.Quotes.Find(id);
        }

        public Quote Create(QuoteModel model)
        {
            var newQuote = new Quote
            {
                Author = model.Author,
                Text = model.Text
            };

            dbContext.Quotes.Add(newQuote);
            dbContext.SaveChanges();

            return newQuote;
        }

        public Quote Update(QuoteUpdateModel model)
        {
            var entity = dbContext.Quotes.Find(model.Id);

            if (entity == null)
                return null;

            entity.Author = model.Author;
            entity.Text = model.Text;

            dbContext.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = dbContext.Quotes.Find(id);

            if (entity == null)
                return;

            dbContext.Quotes.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
