using CalculoHonorario.Business.Interfaces.Notifications;

namespace CalculoHonorario.Business.Notifications;

public class Notificador : INotificador
{
    private List<Notificacao> _noticacoes;

    public Notificador() => _noticacoes = new List<Notificacao>();

    public void Handle(Notificacao notificacao) => _noticacoes.Add(notificacao);

    public List<Notificacao> ObterNotificacoes() => _noticacoes;

    public bool TemNotificacao() => _noticacoes.Any();
}