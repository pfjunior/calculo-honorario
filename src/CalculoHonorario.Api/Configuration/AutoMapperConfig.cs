using AutoMapper;
using CalculoHonorario.Api.Application.Models;
using CalculoHonorario.Api.Domain.Entities;

namespace CalculoHonorario.Api.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Honorario, HonorarioDto>();
        CreateMap<AdicionarHonorarioDto, Honorario>();
    }
}
