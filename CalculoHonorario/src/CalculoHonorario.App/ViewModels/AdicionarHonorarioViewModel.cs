using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CalculoHonorario.App.ViewModels;

public class AdicionarHonorarioViewModel
{
    [DisplayName("Descrição")]
    public string Descricao { get; set; }

    [DisplayName("Renda Mensal")]
    [DataType(DataType.Currency)]
    public decimal RendaMensal { get; set; }

    [DisplayName("Serviço Contábil")]
    [DataType(DataType.Currency)]
    public decimal ServicoContabil { get; set; }

    [DisplayName("Simples Nacional")]
    public double SimplesNacional { get; set; }

    [DisplayName("Tem VR?")]
    public bool TemValeRefeicao { get; set; } = false;

    [DisplayName("Valor do VR")]
    [DataType(DataType.Currency)]
    public decimal ValorVR { get; set; }

    [DisplayName("Tem VT?")]
    public bool TemValeTransporte { get; set; } = false;

    [DisplayName("Valor da Passagem")]
    [DataType(DataType.Currency)]
    public decimal ValorVT { get; set; }

}
