namespace LoginGoldCS.Models.Response;

public class LoginResponse
{
    public bool Success { get; set; }
    public object Result { get; set; }

    public LoginResponse()
    {
    }

    public LoginResponse(bool success, object result)
    {
        Success = success;
        Result = result;
    }
}
