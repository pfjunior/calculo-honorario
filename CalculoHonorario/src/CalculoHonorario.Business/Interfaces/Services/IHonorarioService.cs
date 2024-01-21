using CalculoHonorario.Business.Models;

namespace CalculoHonorario.Business.Interfaces.Services;

public interface IHonorarioService : IDisposable
{
    Task AdicionarAsync(Honorario honorario);
    Task AtualizarAsync(Honorario honorario);
    Task RemoverAsync(Honorario honorario);

    Task<Honorario> ObterPorIdAsync(Guid id);
    Task<List<Honorario>> ObterTodosAsync();
}