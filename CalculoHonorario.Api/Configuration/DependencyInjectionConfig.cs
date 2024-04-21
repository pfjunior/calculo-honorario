using CalculoHonorario.Api.Infra.Data;

namespace CalculoHonorario.Api.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Data
        services.AddScoped<ApplicationContext>();
    }
}

