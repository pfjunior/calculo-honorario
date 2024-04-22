using FluentValidation;
using FluentValidation.Results;

namespace CalculoHonorario.Api.Application.Models;

public class AdicionarHonorarioDto : BaseDto
{
    public string Descricao { get; set; }
    public decimal RendaMensal { get; set; }
    public decimal ServicoContabil { get; set; }
    public decimal SimplesNacional { get; set; }
    public decimal ValorVR { get; set; }
    public decimal ValorVT { get; set; }

    public bool EhValido()
    {
        ValidationResult = new AdicionarHonorarioDtoValidation().Validate(this);
        return ValidationResult.IsValid;
    }


    #region Classe Aninhada
    public class AdicionarHonorarioDtoValidation : AbstractValidator<AdicionarHonorarioDto>
    {
        public AdicionarHonorarioDtoValidation()
        {
            RuleFor(h => h.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");
            RuleFor(h => h.RendaMensal)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado")
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
            RuleFor(h => h.ServicoContabil)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado")
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
            RuleFor(h => h.SimplesNacional)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado")
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
            RuleFor(h => h.ValorVR)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");
            RuleFor(h => h.ValorVT)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado");
        }
    }
    #endregion
}
