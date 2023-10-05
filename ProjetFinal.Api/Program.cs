using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetFinal.Api.Infrastructure;
using ProjetFinal.Api.Persistence;
using ProjetFinal.Api.Services;

namespace ProjetFinal.Api
{
    public class Program
    {
        public static IConfiguration Config { get; private set; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Config = builder.Configuration;

            builder.Services.AddCors();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(AppSwaggerConfiguration.Options);
            builder.Services.AddDbContext<IAppDbContext, AppDbContext>();
            builder.Services.AddTransient<IQuoteService, QuoteService>();

            var app = builder.Build();

            app.ApplyMigrations();
            app.UseCors(builder =>
            {
                builder
                    .WithOrigins("http://127.0.0.1:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });


            // Configure o SwaggerUI com a rota correta
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
