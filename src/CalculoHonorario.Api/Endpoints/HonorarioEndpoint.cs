using CalculoHonorario.Api.Application;
using CalculoHonorario.Api.Application.Models;
using CalculoHonorario.Api.Communication;
using Microsoft.AspNetCore.Mvc;

namespace CalculoHonorario.Api.Endpoints;

public static class HonorarioEndpoint
{
    public static void MapHonorarioEndpoint(this WebApplication app)
    {
        var root = app.MapGroup("/api/honorario").WithOpenApi();

        root.MapGet("/", ObterTodos).Produces<IResult>();
        root.MapGet("/{id}", ObterPorId).Produces<IResult>();

        root.MapPost("/", Adicionar).Produces<IResult>();
    }

    private static async Task<IResult> ObterTodos([FromServices] IHonorarioService _service)
    {
        var resposta = new ResultadoResposta();
        var resultado = await _service.ObterTodosAsync();

        return resposta.RespostaPadrao(resultado);
    }

    private static async Task<IResult> ObterPorId([FromServices] IHonorarioService _service, [FromRoute] Guid id)
    {
        var resposta = new ResultadoResposta();
        var resultado = await _service.ObterPorIdAsync(id);

        if (resultado == null)
        {
            resposta.AdicionarErro("A busca não encontrou resultado");
            return resposta.RespostaPadrao();
        }

        return resposta.RespostaPadrao(resultado);
    }

    private static async Task<IResult> Adicionar([FromServices] IHonorarioService _service, [FromBody] AdicionarHonorarioDto model)
    {
        var resposta = new ResultadoResposta();
        var resultado = await _service.AdicionarAsync(model);

        if (!resultado) resposta.AdicionarErro("Houve um erro ao persistir os dados");

        return resposta.RespostaPadrao();
    }
}