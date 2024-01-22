﻿using System.ComponentModel;

namespace CalculoHonorario.App.ViewModels;

public class AdicionarHonorarioViewModel
{
    [DisplayName("Descrição")]
    public string Descricao { get; set; }

    [DisplayName("Renda Mensal")]
    public decimal RendaMensal { get; set; }

    [DisplayName("Serviço Contábil (R$)")]
    public decimal ServicoContabil { get; set; }

    [DisplayName("Simples Nacional (%)")]
    public decimal SimplesNacional { get; set; }

    [DisplayName("Tem VR?")]
    public bool TemValeRefeicao { get; set; } = false;

    [DisplayName("Valor do VR (R$)")]
    public decimal ValorVR { get; set; }

    [DisplayName("Tem VT?")]
    public bool TemValeTransporte { get; set; } = false;

    [DisplayName("Valor da Passagem (R$)")]
    public decimal ValorVT { get; set; }

}
