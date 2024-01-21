using CalculoHonorario.Business.Notifications;

namespace CalculoHonorario.Business.Interfaces.Notifications;

public interface INotificador
{
    bool TemNotificacao();
    List<Notificacao> ObterNotificacoes();
    void Handle(Notificacao notificacao);
}