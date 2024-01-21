using CalculoHonorario.Business.Interfaces.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CalculoHonorario.App.Controllers;

public abstract class BaseController : Controller
{
    private readonly INotificador _notificador;

    protected BaseController(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected bool OperacaoValida()
    {
        return !_notificador.TemNotificacao();
    }
}
