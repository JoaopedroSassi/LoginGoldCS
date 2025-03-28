namespace LoginGoldCS.Models.Response;

public class LoginResponse
{
    public int? Retorno { get; set; }
    public string? MensagemErro { get; set; }

    public LoginResponse()
    {
    }

    public LoginResponse(int? retorno, string? mensagemErro)
    {
        Retorno = retorno;
        MensagemErro = mensagemErro;
    }
}
