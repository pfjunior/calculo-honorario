namespace CalculoHonorario.Business.Models;

public class Honorario : Entity
{
    protected Honorario() { }

    public Honorario(string descricao, decimal proLabore, decimal servicoContabil)
    {
        Descricao = descricao;
        ProLaboreBruto = proLabore;
        ServicoContabil = servicoContabil;
    }

    public string? Descricao { get; private set; }
    public decimal ProLaboreBruto { get; private set; }
    public decimal ProLaboreLiquido { get; private set; }
    public decimal ProvisaoFerias { get; private set; }
    public decimal ProvisaoDecimoTerceiro { get; private set; }
    public decimal ValeRefeicao { get; private set; }
    public decimal ValeTransporte { get; private set; }
    public decimal Fgts { get; private set; }
    public decimal ServicoContabil { get; private set; }
    public decimal SimplesNacional { get; private set; }
    public decimal Inss { get; private set; }
    public decimal Irpf { get; private set; }
    public decimal ValorHonorario { get; private set; }
    public decimal LucroBruto { get; private set; }
    public decimal LucroLiquido { get; private set; }
    public DateTime CadastradoEm { get; private set; }

    public void CalcularProvisaoFeriasDecimoTerceiro(decimal rendaMensal)
    {
        CalcularProvisaoFerias(rendaMensal);
        CalcularProvisaoDecimoTerceiro(rendaMensal);
    }

    public void CalcularVales(decimal valorVR, decimal valorPassagem)
    {
        if (valorVR == 0) ValeRefeicao = valorVR;
        else CalcularValeRefeicao(valorVR);

        if (valorPassagem == 0) ValeTransporte = valorPassagem;
        else CalcularValeTransporte(valorPassagem);
    }

    public void CalcularLucroBruto()
    {
        LucroBruto = ValorHonorario - SimplesNacional - ServicoContabil;

        CalcularLucroLiquido();
    }


    #region Private Methods
    private const int QUANTIDADE_DIAS = 22;
    private const decimal FGTS_PORCENTAGEM = 8 / 100;
    private const decimal INSS_PORCENTAGEM = 11 / 100;
    private const decimal IRPF_PORCENTAGEM = (decimal)22.50 / 100;
    private const double FATOR_MULTIPLICADOR = 1.06;

    private void CalcularProvisaoFerias(decimal rendaMensal)
    {
        ProvisaoFerias = (rendaMensal / 12) * ((rendaMensal / 12) / 3);

        //CalcularFgts();
    }

    private void CalcularProvisaoDecimoTerceiro(decimal rendaMensal)
    {
        ProvisaoDecimoTerceiro = rendaMensal / 12;

        //CalcularFgts();
    }

    public void CalcularFgts()
    {
        Fgts = (ProLaboreBruto + ProvisaoFerias + ProvisaoDecimoTerceiro) * FGTS_PORCENTAGEM;

        //CalcularInss();
        //CalcularHonorario();
    }

    public void CalcularInss()
    {
        Inss = ProLaboreBruto * INSS_PORCENTAGEM;

        //CalcularProlaboreLiquido();
    }

    private void CalcularValeRefeicao(decimal valor) => ValeRefeicao = valor * QUANTIDADE_DIAS;

    private void CalcularValeTransporte(decimal valor) => ValeTransporte = valor * QUANTIDADE_DIAS;

    public void CalcularProlaboreLiquido() => ProLaboreLiquido = ProLaboreBruto - Inss - Irpf;

    private void CalcularLucroLiquido() => LucroLiquido = LucroBruto - ProLaboreLiquido;

    public void CalcularHonorario() => ValorHonorario = (ProLaboreBruto + ProvisaoFerias + ProvisaoDecimoTerceiro + ValeRefeicao + ValeTransporte + Fgts + ServicoContabil) * (decimal)FATOR_MULTIPLICADOR;

    public void CalcularSimplesNacional(double porcentagem) => SimplesNacional = ValorHonorario * ((decimal)porcentagem / 100);

    public void CalcularIrpf() => Irpf = ProLaboreBruto * IRPF_PORCENTAGEM;
    #endregion
}