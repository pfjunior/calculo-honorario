using CalculoHonorario.Api.Domain.Entities;

namespace CalculoHonorario.Api.Application.Models;

public class HonorarioDto
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public decimal ValorHonorario { get; set; }
    public decimal ProLaboreBruto { get; set; }
    public decimal ProLaboreLiquido { get; set; }
    public decimal Fgts { get; set; }
    public decimal Inss { get; set; }
    public decimal Irpf { get; set; }
    public decimal ServicoContabil { get; set; }
    public decimal SimplesNacional { get; set; }
    public decimal LucroBruto { get; set; }
    public decimal LucroLiquido { get; set; }
    public decimal ProvisaoFerias { get; set; }
    public decimal ProvisaoDecimoTerceiro { get; set; }
    public decimal? ValeRefeicao { get; set; }
    public decimal? ValeTransporte { get; set; }
    public DateTime CadastradoEm { get; set; }


    public static HonorarioDto ParaDto(Honorario honorario)
    {
        return new HonorarioDto
        {
            Id = honorario.Id,
            Descricao = honorario.Descricao,
            ValorHonorario = decimal.Round(honorario.ValorHonorario, 2),
            ProLaboreBruto = decimal.Round(honorario.ProLaboreBruto, 2),
            ProLaboreLiquido = decimal.Round(honorario.ProLaboreLiquido, 2),
            Fgts = decimal.Round(honorario.Fgts, 2),
            Inss = decimal.Round(honorario.Inss, 2),
            Irpf = decimal.Round(honorario.Inss, 2),
            ServicoContabil = decimal.Round(honorario.ServicoContabil, 2),
            SimplesNacional = decimal.Round(honorario.SimplesNacional, 2),
            LucroBruto = decimal.Round(honorario.LucroBruto, 2),
            LucroLiquido = decimal.Round(honorario.LucroLiquido, 2),
            ProvisaoFerias = decimal.Round(honorario.ProvisaoFerias, 2),
            ProvisaoDecimoTerceiro = decimal.Round(honorario.ProvisaoDecimoTerceiro, 2),
            ValeRefeicao = decimal.Round(honorario.ValeRefeicao ?? 0, 2),
            ValeTransporte = decimal.Round(honorario.ValeTransporte ?? 0, 2),
            CadastradoEm = honorario.CadastradoEm
        };
    }
}
