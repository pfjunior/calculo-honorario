using FluentValidation.Results;

namespace CalculoHonorario.Api.Application.Models;

public abstract class BaseDto
{
    public ValidationResult ValidationResult { get; set; }

    public virtual bool EhValido() => throw new NotImplementedException();
}
