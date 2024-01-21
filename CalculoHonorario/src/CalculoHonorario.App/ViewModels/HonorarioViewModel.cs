using CalculoHonorario.Business.Models;

namespace CalculoHonorario.App.ViewModels;

public class HonorarioViewModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public decimal ProLaboreLiquido { get; set; }
    public decimal Fgts { get; private set; }
    public decimal ServicoContabil { get; private set; }
    public decimal SimplesNacional { get; private set; }
    public decimal Inss { get; private set; }
    public decimal Irpf { get; private set; }
    public decimal ValorHonorario { get; private set; }
    public decimal LucroLiquido { get; private set; }


    public HonorarioViewModel MapearParaViewModel(Honorario model)
    {
        return new HonorarioViewModel
        {
            Id = model.Id,
            Descricao = model.Descricao,
            ProLaboreLiquido = model.ProLaboreLiquido,
            Fgts = model.Fgts,
            ServicoContabil = model.ServicoContabil,
            SimplesNacional = model.SimplesNacional,
            Inss = model.Inss,
            Irpf = model.Irpf,
            ValorHonorario = model.ValorHonorario,
            LucroLiquido = model.LucroLiquido,
        };
    }
}
