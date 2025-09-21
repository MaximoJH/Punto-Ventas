using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace Inventory.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Productos",
                    Version = "v1",
                    Description = "Una API REST para gestionar productos con autenticación JWT",
                    Contact = new OpenApiContact
                    {
                        Name = "Maximo Junior Herrera",
                        Email = "maximoh032@hotmail.com"
                    }
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Introduce el token JWT con el prefijo 'Bearer'",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                };

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        securityScheme,
                        Array.Empty<string>()
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);
                c.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
    }
}
