using CalculoHonorario.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CalculoHonorario.App.ViewModels;

public class HonorarioViewModel
{
    public Guid Id { get; set; }

    [DisplayName("Descrição")]
    public string Descricao { get; set; }

    [DisplayName("Valor Honorário")]
    [DataType(DataType.Currency)]
    public decimal ValorHonorario { get; private set; }

    [DisplayName("Pró-Labore Líquido")]
    [DataType(DataType.Currency)]
    public decimal ProLaboreLiquido { get; set; }

    [DisplayName("FGTS")]
    [DataType(DataType.Currency)]
    public decimal Fgts { get; private set; }

    [DisplayName("INSS")]
    [DataType(DataType.Currency)]
    public decimal Inss { get; private set; }

    [DisplayName("IRPF")]
    [DataType(DataType.Currency)]
    public decimal Irpf { get; private set; }

    [DisplayName("Serviço Contábil")]
    [DataType(DataType.Currency)]
    public decimal ServicoContabil { get; private set; }

    [DisplayName("Simples Nacional")]
    [DataType(DataType.Currency)]
    public decimal SimplesNacional { get; private set; }

    [DisplayName("Lucro Líquido")]
    [DataType(DataType.Currency)]
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
