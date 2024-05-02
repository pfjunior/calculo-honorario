using CalculoHonorario.Api.Application.Models;
using CalculoHonorario.Api.Domain.Entities;
using CalculoHonorario.Api.Domain.Interface;

namespace CalculoHonorario.Api.Application;

public class HonorarioService : IHonorarioService
{
    private readonly IHonorarioRepository _repository;

    public HonorarioService(IHonorarioRepository repository) => _repository = repository;


    public async Task<IEnumerable<HonorarioDto>> ObterTodosAsync() => await ObterTodosFormatado();

    public async Task<HonorarioDto> ObterPorIdAsync(Guid id)
    {
        var honorarioDto = await ObterHonorario(id);

        return honorarioDto != null ? honorarioDto : null;
    }

    public async Task<bool> AdicionarAsync(AdicionarHonorarioDto model)
    {
        var honorario = new Honorario(model.Descricao, model.RendaMensal, model.ServicoContabil);
        honorario.CalcularProvisaoFeriasDecimoTerceiro(model.RendaMensal);
        honorario.CalcularVales(model.ValorVR ?? 0, model.ValorVT ?? 0);
        honorario.CalcularBeneficiosPrevidencia();
        honorario.CalcularHonorarioComImposto(model.SimplesNacional);
        honorario.CalcularLucroEProLabore();

        await _repository.AdicionarAsync(honorario);
        return await _repository.UnitOfWork.CommitAsync();
    }

    public async Task<bool> RemoverAsync(Guid id)
    {
        var honorario = await _repository.ObterPorIdAsync(id);

        if (honorario == null) return false;

        _repository.Remover(honorario);
        return await _repository.UnitOfWork.CommitAsync();
    }



    private async Task<HonorarioDto> ObterHonorario(Guid id) => HonorarioDto.ParaDto(await _repository.ObterPorIdAsync(id));

    private async Task<IEnumerable<HonorarioDto>> ObterTodosFormatado()
    {
        var resultado = await _repository.ObterTodosAsync();
        var honorariosDto = new List<HonorarioDto>();

        foreach (var honorarioDto in resultado) honorariosDto.Add(HonorarioDto.ParaDto(honorarioDto));

        return honorariosDto.AsEnumerable();
    }
}
