using CalculoHonorario.App.ViewModels;

namespace CalculoHonorario.App.Services;

public interface IApplicationService
{
    Task<List<HonorarioViewModel>> ObterTodosAsync();
    Task<HonorarioViewModel> ObterPorIdAsync(Guid id);


    Task AdicionarAsync(AdicionarHonorarioViewModel model);
    Task RemoverAsync(Guid id);
}
