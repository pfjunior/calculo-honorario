using CalculoHonorario.App.Services;
using CalculoHonorario.Business.Interfaces.Notifications;
using CalculoHonorario.Business.Interfaces.Repository;
using CalculoHonorario.Business.Interfaces.Services;
using CalculoHonorario.Business.Notifications;
using CalculoHonorario.Business.Services;
using CalculoHonorario.Data.Context;
using CalculoHonorario.Data.Repository;

namespace CalculoHonorario.App.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        // Data
        services.AddScoped<ApplicationContext>();
        services.AddScoped<IHonorarioRepository, HonorarioRepository>();

        // Business
        services.AddScoped<IHonorarioService, HonorarioService>();
        services.AddScoped<INotificador, Notificador>();

        // Application
        services.AddScoped<IApplicationService, ApplicationService>();

        return services;
    }
}
