using CalculoHonorario.Business.Core;
using CalculoHonorario.Business.Interfaces.Notifications;
using CalculoHonorario.Business.Interfaces.Repository;
using CalculoHonorario.Business.Interfaces.Services;
using CalculoHonorario.Business.Models;
using CalculoHonorario.Business.Models.Validations;

namespace CalculoHonorario.Business.Services;

public class HonorarioService : BaseService, IHonorarioService
{
    private readonly IHonorarioRepository _repository;

    public HonorarioService(IHonorarioRepository repository, INotificador notificador) : base(notificador) => _repository = repository;

    public async Task<Honorario> ObterPorIdAsync(Guid id) => await _repository.ObterPorIdAsync(id);

    public async Task<List<Honorario>> ObterTodosAsync() => await _repository.ObterTodosAsync();

    public async Task AdicionarAsync(Honorario honorario)
    {
        if (!ExecutarValidacao(new HonorarioValidation(), honorario)) return;

        await _repository.AdicionarAsync(honorario);
    }

    public async Task AtualizarAsync(Honorario honorario)
    {
        if (!ExecutarValidacao(new HonorarioValidation(), honorario)) return;

        await _repository.AtualizarAsync(honorario);
    }

    public async Task RemoverAsync(Honorario honorario) => await _repository.RemoverAsync(honorario);


    public void Dispose() => _repository?.Dispose();
}