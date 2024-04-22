using FluentValidation.Results;

namespace CalculoHonorario.Api.Communication;

public class ResultadoResposta
{
    public ResultadoResposta() => Erros = new MensagemErroResposta();

    public string Titulo { get; set; }
    public int Status { get; set; }
    public MensagemErroResposta Erros { get; set; }


    public IResult RespostaPadrao(object? result = null)
    {
        return OperacaoValida() ?
            Results.Ok(result) :
            Results.BadRequest(new HttpValidationProblemDetails(new Dictionary<string, string[]> { { "Mensagens", Erros.Mensagens.ToArray() } }));
    }

    public IResult RespostaPadrao(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors) AdicionarErro(error.ErrorMessage);

        return RespostaPadrao();
    }

    public IResult RespostaPadrao(ResultadoResposta resposta)
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

    public void AdicionarErro(string erro) => Erros.Mensagens.Add(erro);

    public void LimparErros() => Erros.Mensagens.Clear();

    protected bool OperacaoValida() => !Erros.Mensagens.Any();


}
