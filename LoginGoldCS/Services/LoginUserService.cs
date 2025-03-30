using LoginGoldCS.Models.Entities;
using LoginGoldCS.Repositories.Interfaces;
using LoginGoldCS.Services.Interfaces;

namespace LoginGoldCS.Services;

public class LoginUserService : ILoginUserService
{
    private readonly ILoginUserRepository _loginUserRepository;

    public LoginUserService(ILoginUserRepository loginUserRepository)
    {
        _loginUserRepository = loginUserRepository;
    }

    public async Task<Login> GetByEmailAsync(string email)
    {
        var ret = await _loginUserRepository.GetByEmailAsync(email);

        return ret;
    }
}
