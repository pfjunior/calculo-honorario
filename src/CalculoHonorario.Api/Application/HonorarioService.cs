using AutoMapper;
using CalculoHonorario.Api.Application.Models;
using CalculoHonorario.Api.Domain.Entities;
using CalculoHonorario.Api.Domain.Interface;

namespace CalculoHonorario.Api.Application;

public class HonorarioService : IHonorarioService
{
    private readonly IHonorarioRepository _repository;
    private readonly IMapper _mapper;

    public HonorarioService(IHonorarioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HonorarioDto>> ObterTodosAsync() => _mapper.Map<IEnumerable<HonorarioDto>>(await _repository.ObterTodosAsync());

    public async Task<HonorarioDto> ObterPorIdAsync(Guid id)
    {
        var honorarioDto = await ObterHonorario(id);

        return honorarioDto != null ? honorarioDto : null;
    }


    public async Task<bool> AdicionarAsync(AdicionarHonorarioDto model)
    {
        var honorario = new Honorario(model.Descricao, model.RendaMensal, model.ServicoContabil);
        honorario.CalcularProvisaoFeriasDecimoTerceiro(model.RendaMensal);
        honorario.CalcularVales(model.ValorVR, model.ValorVT);
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


    private async Task<HonorarioDto> ObterHonorario(Guid id) => _mapper.Map<HonorarioDto>(await _repository.ObterPorIdAsync(id));
}
