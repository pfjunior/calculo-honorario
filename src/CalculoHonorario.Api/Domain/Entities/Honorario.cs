namespace CalculoHonorario.Api.Domain.Entities;

public class Honorario
{
    protected Honorario() { }

    public Honorario(string descricao, decimal proLabore, decimal servicoContabil)
    {
        Id = Guid.NewGuid();
        Descricao = descricao;
        ProLaboreBruto = proLabore;
        ServicoContabil = servicoContabil;
    }

    public Guid Id { get; private set; }
    public string Descricao { get; private set; }
    public decimal ProLaboreBruto { get; private set; }
    public decimal ProLaboreLiquido { get; private set; }
    public decimal LucroBruto { get; private set; }
    public decimal LucroLiquido { get; private set; }
    public decimal ValorHonorario { get; private set; }
    public decimal ProvisaoFerias { get; private set; }
    public decimal ProvisaoDecimoTerceiro { get; private set; }
    public decimal Fgts { get; private set; }
    public decimal Inss { get; private set; }
    public decimal Irpf { get; private set; }
    public decimal? ValeRefeicao { get; private set; }
    public decimal? ValeTransporte { get; private set; }
    public decimal ServicoContabil { get; private set; }
    public decimal SimplesNacional { get; private set; }
    public DateTime CadastradoEm { get; private set; }

    public void CalcularProvisaoFeriasDecimoTerceiro(decimal rendaMensal)
    {
        CalcularProvisaoFerias(rendaMensal);
        CalcularProvisaoDecimoTerceiro(rendaMensal);
    }

    public void CalcularVales(decimal valorVR, decimal valorPassagem)
    {
        if (valorVR == 0) ValeRefeicao = 0;
        else ValeRefeicao = CalcularValeRefeicao(valorVR);

        if (valorPassagem == 0) ValeTransporte = 0;
        else ValeTransporte = CalcularValeTransporte(valorPassagem);
    }

    public void CalcularBeneficiosPrevidencia()
    {
        CalcularFgts();
        CalcularInss();
        CalcularIrpf();
    }

    public void CalcularHonorarioComImposto(decimal porcentamSimplesNacional)
    {
        CalcularHonorario();
        CalcularSimplesNacional(porcentamSimplesNacional);
    }

    public void CalcularLucroEProLabore()
    {
        CalcularLucroBruto();
        CalcularProlaboreLiquido();
        CalcularLucroLiquido();
    }

    #region Metodos Privado
    private const int QUANTIDADE_DIAS = 22;
    private const decimal FGTS_PORCENTAGEM = (decimal)8 / 100;
    private const decimal INSS_PORCENTAGEM = (decimal)11 / 100;
    private const decimal IRPF_PORCENTAGEM = (decimal)22.50 / 100;
    private const decimal FATOR_MULTIPLICADOR = (decimal)1.06;

    private void CalcularProvisaoFerias(decimal rendaMensal) => ProvisaoFerias = decimal.Round(rendaMensal / 12 + rendaMensal / 12 / 3, 2);

    private void CalcularProvisaoDecimoTerceiro(decimal rendaMensal) => ProvisaoDecimoTerceiro = decimal.Round(rendaMensal / 12, 2);

    private decimal CalcularValeRefeicao(decimal valor) => decimal.Round(valor * QUANTIDADE_DIAS, 2);

    private decimal CalcularValeTransporte(decimal valor) => decimal.Round(valor * QUANTIDADE_DIAS, 2);

    private void CalcularFgts() => Fgts = decimal.Round((ProLaboreBruto + ProvisaoFerias + ProvisaoDecimoTerceiro) * FGTS_PORCENTAGEM, 2);

    private void CalcularInss() => Inss = decimal.Round(ProLaboreBruto * INSS_PORCENTAGEM, 2);

    private void CalcularIrpf() => Irpf = decimal.Round(ProLaboreBruto * IRPF_PORCENTAGEM, 2);

    private void CalcularSimplesNacional(decimal porcentagem) => SimplesNacional = decimal.Round(ValorHonorario * (porcentagem / 100), 2);

    private void CalcularHonorario() => ValorHonorario = decimal.Round((ProLaboreBruto + ProvisaoFerias + ProvisaoDecimoTerceiro + ValeRefeicao ?? 0 + ValeTransporte ?? 0 + Fgts + ServicoContabil) * FATOR_MULTIPLICADOR, 2);

    private void CalcularLucroBruto() => LucroBruto = decimal.Round(ValorHonorario - SimplesNacional - ServicoContabil, 2);

    private void CalcularLucroLiquido() => LucroLiquido = decimal.Round(LucroBruto - ProLaboreLiquido, 2);

    public void CalcularProlaboreLiquido() => ProLaboreLiquido = decimal.Round(ProLaboreBruto - Inss - Irpf, 2);
    #endregion
}