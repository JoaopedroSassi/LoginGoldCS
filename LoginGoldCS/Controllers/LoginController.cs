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
            return BadRequest(new LoginResponse(false, "Usuário não encontrado"));
        
        if (!BCrypt.Net.BCrypt.Verify(request.Password, ret.Password))
            return BadRequest(new LoginResponse(false, "Senha incorreta"));

        return Ok(new LoginResponse(true, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImZyYW5jaGVzY29AZ21haWwuY29tIiwidXNlcklkIjoiMyIsIm5hbWUiOiJGcmFuY2hlc2NvIGxlZ2FsIiwicm9sZSI6ImFkbWluIiwibmJmIjoxNzQzMzcyMTI3LCJleHAiOjE3NDM0MDA5MjcsImlhdCI6MTc0MzM3MjEyN30.RSEmTMBfVjPUXIPajMGVXN2KmLps3PkvtS8wH7QZwl0"));
    }
}
