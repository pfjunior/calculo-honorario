using CalculoHonorario.Api.Application.Models;

namespace CalculoHonorario.Api.Application;

public interface IHonorarioService
{
    Task<IEnumerable<HonorarioDto>> ObterTodosAsync();
    Task<HonorarioDto> ObterPorIdAsync(Guid id);


    Task<bool> AdicionarAsync(AdicionarHonorarioDto model);
    Task<bool> RemoverAsync(Guid id);
}
