using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace ProjetFinal.Api.Infrastructure
{
    internal class AppSwaggerConfiguration
    {
        public static void Options(SwaggerGenOptions options)
        {
            var openApiInfo = new OpenApiInfo
            {
                Title = "WEBAPI CITAÇÕES",
                Description = "Projeto WebAPI  com Front para gravar, recuperar, editar e deletar citações",
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("http://www.mit.com/license")
                },
                Contact = new OpenApiContact
                {
                    Name = "Marianna Correa",
                    Email = "mahvalenterj@gmail.com"
                }
            };

            options.SwaggerDoc("v1", openApiInfo);

            var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var path = Path.Combine(AppContext.BaseDirectory, fileName);

            options.IncludeXmlComments(path, true);
        }
    }
}
