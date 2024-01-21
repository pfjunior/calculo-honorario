namespace CalculoHonorario.App.ViewModels;

public class AdicionarHonorarioViewModel
{
    public string Descricao { get; set; }
    public decimal RendaMensal { get; set; }
    public decimal ServicoContabil { get; set; }
    public decimal SimplesNacional { get; set; }
    public bool TemValeRefeicao { get; set; }
    public decimal ValorVR { get; set; }
    public bool TemValeTransporte { get; set; }
    public decimal ValorVT { get; set; }

}
