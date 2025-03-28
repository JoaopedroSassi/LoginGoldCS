using LoginGoldCS.Models.Request;
using LoginGoldCS.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginGoldCS.Controllers;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("LoginUser")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {

        return Ok(new LoginResponse(1, ""));
    }
}
