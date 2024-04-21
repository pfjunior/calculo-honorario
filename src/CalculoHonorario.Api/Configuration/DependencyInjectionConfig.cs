using CalculoHonorario.Api.Domain.Interface;
using CalculoHonorario.Api.Infra.Data;
using CalculoHonorario.Api.Infra.Data.Repository;

namespace CalculoHonorario.Api.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Data
        services.AddScoped<ApplicationContext>();
        services.AddScoped<IHonorarioRepository, HonorarioRepository>();
    }
}

