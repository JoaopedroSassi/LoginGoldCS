using LoginGoldCS.Models.Request;
using LoginGoldCS.Models.Response;
using LoginGoldCS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginGoldCS.Controllers;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginUserService _loginUserService;

    public LoginController(ILoginUserService loginUserService)
    {
        _loginUserService = loginUserService;
    }

    [AllowAnonymous]
    [HttpPost("LoginUser")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var ret = await _loginUserService.GetByEmailAsync(request.Email);

        if (ret is null)       
            return BadRequest(new LoginResponse(-1, "Usuário não encontrado"));
        
        if (!BCrypt.Net.BCrypt.Verify(request.Password, ret.Password))
            return BadRequest(new LoginResponse(-2, "Senha incorreta"));

        return Ok(new LoginResponse(1, ""));
    }
}
