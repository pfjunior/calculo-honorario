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
    public decimal ValorHonorario { get; set; }

    [DisplayName("Pró-Labore Bruto")]
    [DataType(DataType.Currency)]
    public decimal ProLaboreBruto { get; set; }

    [DisplayName("Pró-Labore Líquido")]
    [DataType(DataType.Currency)]
    public decimal ProLaboreLiquido { get; set; }

    [DisplayName("FGTS")]
    [DataType(DataType.Currency)]
    public decimal Fgts { get; set; }

    [DisplayName("INSS")]
    [DataType(DataType.Currency)]
    public decimal Inss { get; set; }

    [DisplayName("IRPF")]
    [DataType(DataType.Currency)]
    public decimal Irpf { get; set; }

    [DisplayName("Serviço Contábil")]
    [DataType(DataType.Currency)]
    public decimal ServicoContabil { get; set; }

    [DisplayName("Simples Nacional")]
    [DataType(DataType.Currency)]
    public decimal SimplesNacional { get; set; }

    [DisplayName("Lucro Bruto")]
    [DataType(DataType.Currency)]
    public decimal LucroBruto { get; set; }

    [DisplayName("Lucro Líquido")]
    [DataType(DataType.Currency)]
    public decimal LucroLiquido { get; set; }

    [DisplayName("Provisão Férias")]
    [DataType(DataType.Currency)]
    public decimal ProvisaoFerias { get; set; }

    [DisplayName("Provisão Décimo Terceiro")]
    [DataType(DataType.Currency)]
    public decimal ProvisaoDecimoTerceiro { get; set; }

    [DisplayName("Vale Refeição")]
    [DataType(DataType.Currency)]
    public decimal ValeRefeicao { get; set; }

    [DisplayName("Vale Transporte")]
    [DataType(DataType.Currency)]
    public decimal ValeTransporte { get; set; }

    [DisplayName("Data Cadastro")]
    [DataType(DataType.DateTime)]
    public DateTime CadastradoEm { get; set; }


    public HonorarioViewModel MapearParaViewModel(Honorario model)
    {
        var teste = new HonorarioViewModel
        {
            Id = model.Id,
            Descricao = model.Descricao,
            ProLaboreBruto = model.ProLaboreBruto,
            ProLaboreLiquido = model.ProLaboreLiquido,
            Fgts = model.Fgts,
            ServicoContabil = model.ServicoContabil,
            SimplesNacional = model.SimplesNacional,
            Inss = model.Inss,
            Irpf = model.Irpf,
            ValorHonorario = model.ValorHonorario,
            LucroBruto = model.LucroBruto,
            LucroLiquido = model.LucroLiquido,
            ProvisaoFerias = model.ProvisaoFerias,
            ProvisaoDecimoTerceiro = model.ProvisaoDecimoTerceiro,
            ValeRefeicao = model.ValeRefeicao,
            ValeTransporte = model.ValeTransporte,
        };

        return teste;
    }
}
