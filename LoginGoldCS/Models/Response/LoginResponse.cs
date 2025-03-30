namespace LoginGoldCS.Models.Response;

public class LoginResponse
{
    public int CodigoRetorno { get; set; }
    public string MensagemErro { get; set; }

    public LoginResponse()
    {
    }

    public LoginResponse(int codigoRetorno, string mensagemErro)
    {
        CodigoRetorno = codigoRetorno;
        MensagemErro = mensagemErro;
    }
}
