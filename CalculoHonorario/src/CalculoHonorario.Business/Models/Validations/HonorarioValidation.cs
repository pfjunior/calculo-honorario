using FluentValidation;

namespace CalculoHonorario.Business.Models.Validations;

public class HonorarioValidation : AbstractValidator<Honorario>
{
    public HonorarioValidation()
    {
        RuleFor(h => h.ServicoContabil)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado")
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

        RuleFor(h => h.SimplesNacional)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado")
            .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
    }
}