namespace CalculoHonorario.Api.Communication;

public class MensagemErroResposta
{
    public MensagemErroResposta() => Mensagens = new List<string>();

    public List<string> Mensagens { get; set; }
}
