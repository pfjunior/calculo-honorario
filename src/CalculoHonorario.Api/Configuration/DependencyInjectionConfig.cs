using CalculoHonorario.Api.Application;
using CalculoHonorario.Api.Application.Models;
using CalculoHonorario.Api.Domain.Interface;
using CalculoHonorario.Api.Infra.Data;
using CalculoHonorario.Api.Infra.Data.Repository;
using FluentValidation;
using static CalculoHonorario.Api.Application.Models.AdicionarHonorarioDto;

namespace CalculoHonorario.Api.Configuration;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Data
        services.AddScoped<ApplicationContext>();
        services.AddScoped<IHonorarioRepository, HonorarioRepository>();

        // Services
        services.AddScoped<IHonorarioService, HonorarioService>();

        // Validation
        services.AddScoped<IValidator<AdicionarHonorarioDto>, AdicionarHonorarioDtoValidation>();
    }
}

