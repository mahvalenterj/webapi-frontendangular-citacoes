using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ProjetFinal.Api.Infrastructure
{
    public static class AppCorsConfiguration
    {
        internal static void AllowAnything(CorsPolicyBuilder builder)
        {
            builder.AllowAnyMethod().AllowAnyHeader();
        }
    }
}
