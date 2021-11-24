using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NSE.Catalogo.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo()
                {
                    Title = "NerdStore Enterprise Catálogo API",
                    Description = "API de Catálogo",
                    Contact = new OpenApiContact() { Name = "Bruno Verçosa", Email = "bruno.nv@hotmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri(uriString: "google.com.br") }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "v1");
            });
        }
    }
}
