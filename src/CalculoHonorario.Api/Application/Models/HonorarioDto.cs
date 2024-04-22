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
    public decimal ValeRefeicao { get; set; }
    public decimal ValeTransporte { get; set; }
    public DateTime CadastradoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
}
