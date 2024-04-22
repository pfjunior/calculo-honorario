using FluentValidation.Results;

namespace CalculoHonorario.Api.Communication;

public class ResultadoResposta
{
    public ResultadoResposta() => Erros = new MensagemErroResposta();

    public string Titulo { get; set; }
    public int Status { get; set; }
    public MensagemErroResposta Erros { get; set; }


    protected IResult RespostaPadrao(object? result = null)
    {
        return OperacaoValida() ?
            Results.Ok(result) :
            Results.BadRequest(new HttpValidationProblemDetails(new Dictionary<string, string[]> { { "Mensagens", Erros.Mensagens.ToArray() } }));
    }

    protected IResult RespostaPadrao(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors) AdicionarErro(error.ErrorMessage);

        return RespostaPadrao();
    }

    protected IResult RespostaPadrao(ResultadoResposta resposta)
    {
        RespostaPossuiErros(resposta);

        return RespostaPadrao();
    }

    protected bool RespostaPossuiErros(ResultadoResposta resposta)
    {
        if (resposta is null || !resposta.Erros.Mensagens.Any()) return false;

        foreach (var mensagem in resposta!.Erros.Mensagens) AdicionarErro(mensagem);

        return true;
    }

    protected bool OperacaoValida() => !Erros.Mensagens.Any();

    protected void AdicionarErro(string erro) => Erros.Mensagens.Add(erro);

    protected void LimparErros() => Erros.Mensagens.Clear();
}
