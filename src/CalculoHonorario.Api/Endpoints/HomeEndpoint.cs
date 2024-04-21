namespace CalculoHonorario.Api.Endpoints;

public static class HomeEndpoint
{
    public static void MapHomeEndpoint(this WebApplication app) => app.MapGet("/", () => Results.Ok("Teste"));
}
