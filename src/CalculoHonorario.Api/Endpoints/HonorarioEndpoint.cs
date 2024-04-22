using CalculoHonorario.Api.Application;
using CalculoHonorario.Api.Application.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CalculoHonorario.Api.Endpoints;

public static class HonorarioEndpoint
{
    public static void MapHonorarioEndpoint(this WebApplication app)
    {
        var root = app.MapGroup("/api/honorario").WithOpenApi();

        root.MapGet("/", ObterTodos)
            .Produces<HonorarioDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("ObterTodos");

        root.MapGet("/{id}", ObterPorId)
            .Produces<HonorarioDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("ObterPorId");

        root.MapPost("/", Adicionar)
            .Produces<HonorarioDto>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem()
            .WithName("Adicionar");

        root.MapDelete("/{id}", Remover)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Remover");
    }

    private static async Task<IResult> ObterTodos([FromServices] IHonorarioService _service)
    {
        var resultado = await _service.ObterTodosAsync();

        return resultado.Any() ? Results.Ok(resultado) : Results.NotFound("A busca não encontrou nenhum registro");
    }

    private static async Task<IResult> ObterPorId([FromServices] IHonorarioService _service, [FromRoute] Guid id)
    {
        var resultado = await _service.ObterPorIdAsync(id);

        return resultado != null ? Results.Ok(resultado) : Results.NotFound("Não foi possível encontrar o registro com o id informado");
    }

    private static async Task<IResult> Adicionar(IValidator<AdicionarHonorarioDto> validator, [FromServices] IHonorarioService _service, [FromBody] AdicionarHonorarioDto model)
    {
        ValidationResult validationResult = await validator.ValidateAsync(model);

        if (!validationResult.IsValid) return Results.ValidationProblem(validationResult.ToDictionary());

        var resultado = await _service.AdicionarAsync(model);

        return resultado ? Results.Created() : Results.BadRequest("Houve um erro ao persistir o registro");
    }

    private static async Task<IResult> Remover([FromServices] IHonorarioService _service, [FromRoute] Guid id)
    {
        var honorario = await _service.ObterPorIdAsync(id);
        if (honorario == null) return Results.NotFound("Não foi possível encontrar o registro com o id informado");

        var resultado = await _service.RemoverAsync(id);

        return resultado ? Results.NoContent() : Results.BadRequest("Houve um erro ao remover o registro");
    }
}