using CalculoHonorario.App.ViewModels;
using CalculoHonorario.Business.Core;
using CalculoHonorario.Business.Interfaces.Notifications;
using CalculoHonorario.Business.Interfaces.Services;
using CalculoHonorario.Business.Models;

namespace CalculoHonorario.App.Services;

public class ApplicationService : BaseService
{
    private readonly IHonorarioService _service;

    public ApplicationService(IHonorarioService service, INotificador notificador) : base(notificador)
    {
        _service = service;
    }

    public async Task<Honorario> ObterPorIdAsync(Guid id) => await _service.ObterPorIdAsync(id);

    public async Task<List<HonorarioViewModel>> ObterTodosAsync()
    {
        var model = await _service.ObterTodosAsync();
        var viewModel = new HonorarioViewModel();
        var list = new List<HonorarioViewModel>();

        model.ForEach(item => list.Add(viewModel.MapearParaViewModel(item)));

        return list;

    }

    public async Task AdicionarAsync(AdicionarHonorarioViewModel model)
    {
        var honorario = new Honorario(model.Descricao, model.RendaMensal, model.ServicoContabil, model.SimplesNacional);
        honorario.CalcularProvisaoFeriasDecimoTerceiro(model.RendaMensal);
        // TODO: Refatorar o calculo do vale transporte quando tiver mais de uma passagem
        honorario.CalcularVales(model.TemValeRefeicao ? model.ValorVR : 0, model.TemValeTransporte ? model.ValorVT : 0);
        honorario.CalcularLucroBruto();

        await _service.AdicionarAsync(honorario);
    }

    public async Task RemoverAsync(Guid id)
    {
        var honorario = await _service.ObterPorIdAsync(id);

        if (honorario == null)
        {
            Notificar("Honorário não existe");
            return;
        }

        await _service.RemoverAsync(honorario);
    }
}
