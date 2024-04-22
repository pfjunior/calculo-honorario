using FluentValidation.Results;

namespace CalculoHonorario.Api.Application;

public abstract class Service
{
    protected ValidationResult ValidationResult;

    protected Service() => ValidationResult = new ValidationResult();

    protected void AdicionarErro(string mensagem) => ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
}
