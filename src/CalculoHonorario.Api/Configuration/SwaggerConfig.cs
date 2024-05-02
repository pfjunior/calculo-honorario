using Microsoft.OpenApi.Models;

namespace CalculoHonorario.Api.Configuration;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Cálculo Honorário",
                Description = "API para calcular honorários de uma Pessoa Jurídica (PJ)",
                Contact = new OpenApiContact() { Name = "Paulo Junior", Url = new Uri("https://www.linkedin.com/in/pfjunior89/") },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
    }
}
