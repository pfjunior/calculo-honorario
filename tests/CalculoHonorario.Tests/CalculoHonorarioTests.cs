using CalculoHonorario.Api.Domain.Entities;

namespace CalculoHonorario.Tests;

public class CalculoHonorarioTests
{
    private const string DESCRICAO = "Proposta Teste 01";
    private const decimal RENDA_MENSAL = (decimal)8500.00;
    private const decimal SERVICO_CONTABIL = (decimal)179.00;
    private const decimal SIMPLES_NACIONAL = 6; // Valor percentual
    private const decimal VALOR_VR = (decimal)35.50;
    private const decimal VALOR_VT = (decimal)12.40;

    [Fact(DisplayName = "Calcular Provisão de Férias e Décimo Terceiro")]
    [Trait("Calculo", "Beneficios")]
    public void CalcularProvisaoFeriasDecimoTerceiro()
    {
        // Arrange
        var honorario = new Honorario(DESCRICAO, RENDA_MENSAL, SERVICO_CONTABIL);

        // Act
        honorario.CalcularProvisaoFeriasDecimoTerceiro(RENDA_MENSAL);

        // Assert
        Assert.Equal(944.44m, honorario.ProvisaoFerias);
        Assert.Equal(708.33m, honorario.ProvisaoDecimoTerceiro);
    }

    [Fact(DisplayName = "Calcular VR e VT")]
    [Trait("Calculo", "Beneficios")]
    public void CalcularVales()
    {
        // Arrange
        var honorario = new Honorario(DESCRICAO, RENDA_MENSAL, SERVICO_CONTABIL);

        // Act
        honorario.CalcularVales(VALOR_VR, VALOR_VT);

        // Assert
        Assert.Equal(781.00m, honorario.ValeRefeicao);
        Assert.Equal(272.80m, honorario.ValeTransporte);
    }

    [Fact(DisplayName = "Calcular Beneficios da Providencia")]
    [Trait("Calculo", "Beneficios")]
    public void CalcularBeneficiosPrevidencia()
    {
        // Arrange
        var honorario = new Honorario(DESCRICAO, RENDA_MENSAL, SERVICO_CONTABIL);

        // Act
        honorario.CalcularProvisaoFeriasDecimoTerceiro(RENDA_MENSAL);
        honorario.CalcularBeneficiosPrevidencia();

        // Assert
        Assert.Equal(812.22m, honorario.Fgts);
        Assert.Equal(935.00m, honorario.Inss);
        Assert.Equal(1912.50m, honorario.Irpf);
    }

    [Fact(DisplayName = "Calcular Honorario com Imposto")]
    [Trait("Calculo", "Beneficios")]
    public void CalcularHonorarioImposto()
    {
        // Arrange
        var honorario = new Honorario(DESCRICAO, RENDA_MENSAL, SERVICO_CONTABIL);

        // Act
        honorario.CalcularProvisaoFeriasDecimoTerceiro(RENDA_MENSAL);
        honorario.CalcularVales(VALOR_VR, VALOR_VT);
        honorario.CalcularBeneficiosPrevidencia();
        honorario.CalcularHonorarioComImposto(SIMPLES_NACIONAL);

        // Assert
        Assert.Equal(12929.66m, honorario.ValorHonorario);
    }

    [Fact(DisplayName = "Calcular Lucro Liquido e Pro-Labore Liquido")]
    [Trait("Calculo", "Beneficios")]
    public void CalcularLucroProLabore()
    {
        // Arrange
        var honorario = new Honorario(DESCRICAO, RENDA_MENSAL, SERVICO_CONTABIL);

        // Act
        honorario.CalcularProvisaoFeriasDecimoTerceiro(RENDA_MENSAL);
        honorario.CalcularVales(VALOR_VR, VALOR_VT);
        honorario.CalcularBeneficiosPrevidencia();
        honorario.CalcularHonorarioComImposto(SIMPLES_NACIONAL);
        honorario.CalcularLucroEProLabore();

        // Assert
        Assert.Equal(11974.88m, honorario.LucroBruto);
        Assert.Equal(6322.38m, honorario.LucroLiquido);
        Assert.Equal(5652.50m, honorario.ProLaboreLiquido);
    }
}