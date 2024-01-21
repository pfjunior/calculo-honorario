using CalculoHonorario.Business.Interfaces.Notifications;
using CalculoHonorario.Business.Models;
using CalculoHonorario.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace CalculoHonorario.Business.Core;

public abstract class BaseService
{
    private readonly INotificador _notificador;

    protected BaseService(INotificador notificador) => _notificador = notificador;

    protected bool ExecutarValidacao<TValidacao, TEntity>(TValidacao validacao, TEntity entidade) where TValidacao : AbstractValidator<TEntity> where TEntity : Entity
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notificar(validator);

        return false;
    }

    protected void Notificar(string mensagem) => _notificador.Handle(new Notificacao(mensagem));

    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var item in validationResult.Errors) Notificar(item.ErrorMessage);
    }
}